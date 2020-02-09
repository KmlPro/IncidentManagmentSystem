using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BuildingBlocks.Application.Commands;
using IncidentReport.Application.Common;
using IncidentReport.Application.Files;
using IncidentReport.Domain.Employees.ValueObjects;
using IncidentReport.Domain.IncidentVerificationApplications;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IncidentReport.Application.IncidentVerificationApplications.UpdateIncidentVerificationApplications
{
    internal class UpdateIncidentVerificationApplicationCommandHandler : ICommandHandler<UpdateIncidentVerificationApplicationCommand>
    {
        private readonly IIncidentReportDbContext _incidentReportContext;
        private readonly IFileStorageService _fileStorageService;
        public UpdateIncidentVerificationApplicationCommandHandler(IIncidentReportDbContext incidentReportContext, IFileStorageService fileStorageService)
        {
            this._incidentReportContext = incidentReportContext;
            this._fileStorageService = fileStorageService;
        }

        public async Task<Unit> Handle(UpdateIncidentVerificationApplicationCommand request, CancellationToken cancellationToken)
        {
            var draftIncidentVerificationApplication = await this._incidentReportContext.DraftIncidentVerificationApplication.FirstAsync(x => x.Id == new DraftApplicationId(request.DraftIncidentVerificationApplicationId));

            this.UpdateApplicationData(draftIncidentVerificationApplication, request);

            if (this.IfAddedAttachmentsExists(request))
            {
                var files = await this.UploadFilesToStorage(request);
                this.AddUploadedFilesAsAttachments(draftIncidentVerificationApplication, files);
            }

            if (this.IfDeletedAttachmentExists(request))
            {
                this.DeleteAttachments(draftIncidentVerificationApplication, request);
            }

            return Unit.Value;
        }

        private void UpdateApplicationData(DraftIncidentVerificationApplication draftIncidentVerificationApplication, UpdateIncidentVerificationApplicationCommand request)
        {
            draftIncidentVerificationApplication.Update(
                new ContentOfApplication(request.Title, request.Content),
                request.IncidentType,
                new SuspiciousEmployees(request.SuspiciousEmployees.Select(x => new EmployeeId(x)))
                );
        }

        private bool IfAddedAttachmentsExists(UpdateIncidentVerificationApplicationCommand request)
        {
            return request.DeletedAttachments != null && request.AddedAttachments.Any();
        }

        private void AddUploadedFilesAsAttachments(DraftIncidentVerificationApplication draftIncidentVerificationApplication, List<UploadedFile> files)
        {
            var attachments = files.Select(x => new IncidentVerificationApplicationAttachment(new FileInfo(x.FileName), new StorageId(x.StorageId)));
            draftIncidentVerificationApplication.AddAttachments(attachments);
        }

        private Task<List<UploadedFile>> UploadFilesToStorage(UpdateIncidentVerificationApplicationCommand request)
        {
            return this._fileStorageService.UploadFiles(request.AddedAttachments);
        }

        private bool IfDeletedAttachmentExists(UpdateIncidentVerificationApplicationCommand request)
        {
            return request.DeletedAttachments != null && request.DeletedAttachments.Any();
        }

        private void DeleteAttachments(DraftIncidentVerificationApplication draftIncidentVerificationApplication, UpdateIncidentVerificationApplicationCommand request)
        {
            draftIncidentVerificationApplication.DeleteAttachments(request.DeletedAttachments.Select(x => new StorageId(x)));
        }
    }
}
