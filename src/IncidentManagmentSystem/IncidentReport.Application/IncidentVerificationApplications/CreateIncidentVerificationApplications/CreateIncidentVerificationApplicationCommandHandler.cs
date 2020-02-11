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
using MediatR;

namespace IncidentReport.Application.IncidentVerificationApplications.CreateIncidentVerificationApplications
{
    public class CreateIncidentVerificationApplicationCommandHandler : ICommandHandler<CreateIncidentVerificationApplicationCommand>
    {
        private readonly IIncidentReportDbContext _incidentReportContext;
        private readonly IFileStorageService _fileStorageService;
        private readonly ICurrentUserContext _applicantContext;
        public CreateIncidentVerificationApplicationCommandHandler(IIncidentReportDbContext incidentReportContext, ICurrentUserContext userContext, IFileStorageService fileStorageService)
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
                new ContentOfApplication(request.Title, request.Description),
                request.IncidentType,
                new EmployeeId(this._applicantContext.UserId),
                new SuspiciousEmployees(request.SuspiciousEmployees.Select(x => new EmployeeId(x)))
                );
        }

        private bool IfAddedAttachmentsExists(CreateIncidentVerificationApplicationCommand request)
        {
            return request.Attachments != null && request.Attachments.Any();
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
