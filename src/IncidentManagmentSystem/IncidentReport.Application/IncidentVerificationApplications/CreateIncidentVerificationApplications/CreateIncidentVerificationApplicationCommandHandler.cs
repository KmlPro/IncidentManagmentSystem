using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BuildingBlocks.Application.Commands;
using IncidentReport.Application.Common;
using IncidentReport.Application.Common.File;
using IncidentReport.Application.User;
using IncidentReport.Domain.IncidentVerificationApplications;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;
using IncidentReport.Domain.Users;
using MediatR;

namespace IncidentReport.Application.IncidentVerificationApplications.CreateIncidentVerificationApplications
{
    internal class CreateIncidentVerificationApplicationCommandHandler : ICommandHandler<CreateIncidentVerificationApplicationCommand>
    {
        private readonly IIncidentReportContext _incidentReportContext;
        private readonly IFileStorageService _fileStorageService;
        private readonly IApplicantContext _applicantContext;
        public CreateIncidentVerificationApplicationCommandHandler(IIncidentReportContext incidentReportContext, IApplicantContext userContext, IFileStorageService fileStorageService)
        {
            this._incidentReportContext = incidentReportContext;
            this._applicantContext = userContext;
            this._fileStorageService = fileStorageService;
        }

        public async Task<Unit> Handle(CreateIncidentVerificationApplicationCommand request, CancellationToken cancellationToken)
        {
            var incidentVerificationApplication = this.CreateDraft(request);

            if (this.IfAddedAttachmentsExists(request))
            {
                var files = await this.UploadFilesToStorage(request);
                this.AddUploadedFilesAsAttachments(incidentVerificationApplication, files);
            }

            await this._incidentReportContext.DraftIncidentVerificationApplication.AddAsync(incidentVerificationApplication);

            return Unit.Value;
        }

        private DraftIncidentVerificationApplication CreateDraft(CreateIncidentVerificationApplicationCommand request)
        {
            return new DraftIncidentVerificationApplication(
                new ContentOfApplication(request.Title, request.Content),
                request.IncidentType,
                new UserId(this._applicantContext.UserId),
                new SuspiciousEmployees(request.SuspiciousEmployees.Select(x => new UserId(x)))
                );
        }

        private bool IfAddedAttachmentsExists(CreateIncidentVerificationApplicationCommand request)
        {
            return request.Attachments.Any();
        }

        private Task<List<UploadedFile>> UploadFilesToStorage(CreateIncidentVerificationApplicationCommand request)
        {
            return this._fileStorageService.UploadFiles(request.Attachments);
        }

        private void AddUploadedFilesAsAttachments(DraftIncidentVerificationApplication incidentVerificationApplication, List<UploadedFile> files)
        {
            var attachments = files.Select(x => new IncidentVerificationApplicationAttachment(new FileInfo(x.FileName), new StorageId(x.StorageId)));
            incidentVerificationApplication.AddAttachments(attachments);
        }
    }
}
