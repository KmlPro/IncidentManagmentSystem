using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using IncidentReport.Application.Boundaries.UpdateDraftApplications;
using IncidentReport.Application.Common;
using IncidentReport.Application.Files;
using IncidentReport.Domain.Employees.ValueObjects;
using IncidentReport.Domain.IncidentVerificationApplications;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace IncidentReport.Application.UseCases
{
    //kbytner 19.03.2020 - implementation not completed
    internal class UpdateDraftApplicationUseCase : IUseCase
    {
        private readonly IIncidentReportDbContext _incidentReportContext;
        private readonly IFileStorageService _fileStorageService;
        private readonly IOutputPort _outputPort;
        public UpdateDraftApplicationUseCase(IIncidentReportDbContext incidentReportContext,
            IFileStorageService fileStorageService,
            IOutputPort outputPort)
        {
            this._incidentReportContext = incidentReportContext;
            this._fileStorageService = fileStorageService;
            this._outputPort = outputPort;
        }

        public async Task<IOutputPort> Handle(UpdateDraftApplicationInput input, CancellationToken cancellationToken)
        {
            var draftIncidentVerificationApplication = await this._incidentReportContext.DraftApplications.FirstAsync(x => x.Id == new DraftApplicationId(input.DraftApplicationId));

            this.UpdateApplicationData(draftIncidentVerificationApplication, input);

            if (this.IfAddedAttachmentsExists(input))
            {
                var files = await this.UploadFilesToStorage(input);
                this.AddUploadedFilesAsAttachments(draftIncidentVerificationApplication, files);
            }

            if (this.IfDeletedAttachmentExists(input))
            {
                this.DeleteAttachments(draftIncidentVerificationApplication, input);
            }

            return this._outputPort;
        }

        private void UpdateApplicationData(DraftApplication draftApplication, UpdateDraftApplicationInput request)
        {
            draftApplication.Update(
                new ContentOfApplication(request.Title, request.Description),
                request.IncidentType,
                new SuspiciousEmployees(request.SuspiciousEmployees.Select(x => new EmployeeId(x)))
                );
        }

        private bool IfAddedAttachmentsExists(UpdateDraftApplicationInput request)
        {
            return request.DeletedAttachments != null && request.AddedAttachments.Any();
        }

        private void AddUploadedFilesAsAttachments(DraftApplication draftIncidentVerificationApplication, List<UploadedFile> files)
        {
            var attachments = files.Select(x => new Attachment(new FileInfo(x.FileName), new StorageId(x.StorageId))).ToList();
            draftIncidentVerificationApplication.AddAttachments(attachments);
        }

        private Task<List<UploadedFile>> UploadFilesToStorage(UpdateDraftApplicationInput request)
        {
            return this._fileStorageService.UploadFiles(request.AddedAttachments);
        }

        private bool IfDeletedAttachmentExists(UpdateDraftApplicationInput request)
        {
            return request.DeletedAttachments != null && request.DeletedAttachments.Any();
        }

        private void DeleteAttachments(DraftApplication draftIncidentVerificationApplication, UpdateDraftApplicationInput request)
        {
            draftIncidentVerificationApplication.DeleteAttachments(request.DeletedAttachments.Select(x => new StorageId(x)));
        }
    }
}
