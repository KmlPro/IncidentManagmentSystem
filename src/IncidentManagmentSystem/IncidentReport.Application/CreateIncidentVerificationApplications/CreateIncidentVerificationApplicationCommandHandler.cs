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

namespace IncidentReport.Application.CreateIncidentVerificationApplications
{
    public class CreateIncidentVerificationApplicationCommandHandler : ICommandHandler<CreateIncidentVerificationApplicationCommand>
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
            var incidentVerificationApplication = this.CreateDraftIncidentVerificationApplication(request);

            if (request.Attachments.Any())
            {
                var files = await this._fileStorageService.UploadFiles(request.Attachments);
                this.AddUploadedFilesAsAttachments(incidentVerificationApplication, files);
            }

            await this._incidentReportContext.DraftIncidentVerificationApplication.AddAsync(incidentVerificationApplication);

            return Unit.Value;
        }

        private DraftIncidentVerificationApplication CreateDraftIncidentVerificationApplication(CreateIncidentVerificationApplicationCommand request)
        {
            return new DraftIncidentVerificationApplication(
                new ContentOfApplication(request.Title, request.Content),
                request.IncidentType,
                new UserId(this._applicantContext.UserId),
                new SuspiciousEmployees(request.SuspiciousEmployees.Select(x => new UserId(x)))
                );
        }

        private void AddUploadedFilesAsAttachments(DraftIncidentVerificationApplication incidentVerificationApplication, List<UploadedFile> files)
        {
            var attachments = files.Select(x => new IncidentVerificationApplicationAttachment(new FileInfo(x.FileName), new StorageId(x.StorageId)));
            incidentVerificationApplication.AddAttachments(attachments);
        }
    }
}
