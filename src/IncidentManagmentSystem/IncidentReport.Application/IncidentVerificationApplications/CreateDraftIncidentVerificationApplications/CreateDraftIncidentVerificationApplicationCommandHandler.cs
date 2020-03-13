using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BuildingBlocks.Application;
using BuildingBlocks.Application.Commands;
using IncidentReport.Application.Common;
using IncidentReport.Application.Files;
using IncidentReport.Domain.Employees.ValueObjects;
using IncidentReport.Domain.IncidentVerificationApplications;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;

namespace IncidentReport.Application.IncidentVerificationApplications.CreateDraftIncidentVerificationApplications
{
    public class CreateDraftIncidentVerificationApplicationCommandHandler : ICommandHandler<CreateDraftIncidentVerificationApplicationCommand, EntityCreatedCommandResult<DraftIncidentVerificationApplication>>
    {

        private readonly IIncidentReportDbContext _incidentReportContext;
        private readonly IFileStorageService _fileStorageService;
        private readonly ICurrentUserContext _applicantContext;

        public CreateDraftIncidentVerificationApplicationCommandHandler(IIncidentReportDbContext incidentReportContext, ICurrentUserContext userContext, IFileStorageService fileStorageService)
        {
            this._incidentReportContext = incidentReportContext;
            this._applicantContext = userContext;
            this._fileStorageService = fileStorageService;
        }

        public async Task<EntityCreatedCommandResult<DraftIncidentVerificationApplication>> Handle(CreateDraftIncidentVerificationApplicationCommand request, CancellationToken cancellationToken)
        {
            var draftIncidentVerificationApplication = this.CreateDraft(request);

            if (this.IfAddedAttachmentsExists(request))
            {
                var files = await this.UploadFilesToStorage(request);
                this.AddUploadedFilesAsAttachments(draftIncidentVerificationApplication, files);
            }

            await this._incidentReportContext.DraftIncidentVerificationApplication.AddAsync(draftIncidentVerificationApplication);

            return new EntityCreatedCommandResult<DraftIncidentVerificationApplication>(draftIncidentVerificationApplication.Id.Value, draftIncidentVerificationApplication);
        }

        private DraftIncidentVerificationApplication CreateDraft(CreateDraftIncidentVerificationApplicationCommand request)
        {
            return new DraftIncidentVerificationApplication(
                new ContentOfApplication(request.Title, request.Description),
                request.IncidentType,
                new EmployeeId(this._applicantContext.UserId),
                new SuspiciousEmployees(request.SuspiciousEmployees.Select(x => new EmployeeId(x)))
                );
        }

        private bool IfAddedAttachmentsExists(CreateDraftIncidentVerificationApplicationCommand request)
        {
            return request.Attachments != null && request.Attachments.Any();
        }

        private Task<List<UploadedFile>> UploadFilesToStorage(CreateDraftIncidentVerificationApplicationCommand request)
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
