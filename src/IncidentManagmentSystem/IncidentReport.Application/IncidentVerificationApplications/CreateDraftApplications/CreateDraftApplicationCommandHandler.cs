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
    public class CreateDraftApplicationCommandHandler : ICommandHandlerWithResult<CreateDraftApplicationCommand, EntityCreatedCommandResult<DraftApplication>>
    {

        private readonly IIncidentReportDbContext _incidentReportContext;
        private readonly IFileStorageService _fileStorageService;
        private readonly ICurrentUserContext _applicantContext;

        public CreateDraftApplicationCommandHandler(IIncidentReportDbContext incidentReportContext, ICurrentUserContext userContext, IFileStorageService fileStorageService)
        {
            this._incidentReportContext = incidentReportContext;
            this._applicantContext = userContext;
            this._fileStorageService = fileStorageService;
        }

        public async Task<EntityCreatedCommandResult<DraftApplication>> Handle(CreateDraftApplicationCommand request, CancellationToken cancellationToken)
        {
            var draftIncidentVerificationApplication = this.CreateDraft(request);

            if (this.IfAddedAttachmentsExists(request))
            {
                var files = await this.UploadFilesToStorage(request);
                this.AddUploadedFilesAsAttachments(draftIncidentVerificationApplication, files);
            }

            await this._incidentReportContext.DraftIncidentVerificationApplication.AddAsync(draftIncidentVerificationApplication);

            return new EntityCreatedCommandResult<DraftApplication>(draftIncidentVerificationApplication.Id.Value, draftIncidentVerificationApplication);
        }

        private DraftApplication CreateDraft(CreateDraftApplicationCommand request)
        {
            return new DraftApplication(
                new ContentOfApplication(request.Title, request.Description),
                request.IncidentType,
                new EmployeeId(this._applicantContext.UserId),
                new SuspiciousEmployees(request.SuspiciousEmployees.Select(x => new EmployeeId(x)))
                );
        }

        private bool IfAddedAttachmentsExists(CreateDraftApplicationCommand request)
        {
            return request.Attachments != null && request.Attachments.Any();
        }

        private Task<List<UploadedFile>> UploadFilesToStorage(CreateDraftApplicationCommand request)
        {
            return this._fileStorageService.UploadFiles(request.Attachments);
        }

        private void AddUploadedFilesAsAttachments(DraftApplication incidentVerificationApplication, List<UploadedFile> files)
        {
            var attachments = files.Select(x => new IncidentVerificationApplicationAttachment(new FileInfo(x.FileName), new StorageId(x.StorageId)));
            incidentVerificationApplication.AddAttachments(attachments);
        }
    }
}
