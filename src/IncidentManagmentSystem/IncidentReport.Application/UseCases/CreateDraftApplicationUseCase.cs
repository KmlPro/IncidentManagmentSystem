using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BuildingBlocks.Application;
using BuildingBlocks.Application.Abstract;
using BuildingBlocks.Domain.Abstract;
using IncidentReport.Application.Boundaries.CreateDraftApplications;
using IncidentReport.Application.Common;
using IncidentReport.Application.Files;
using IncidentReport.Domain.Employees.ValueObjects;
using IncidentReport.Domain.IncidentVerificationApplications;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;
using MediatR;

namespace IncidentReport.Application.UseCases
{
    public class CreateDraftApplicationUseCase : IUseCase
    {
        private readonly IIncidentReportDbContext _incidentReportContext;
        private readonly IFileStorageService _fileStorageService;
        private readonly ICurrentUserContext _applicantContext;
        private readonly IOutputPort _outputPort;
        public CreateDraftApplicationUseCase(IIncidentReportDbContext incidentReportContext,
            ICurrentUserContext userContext,
            IFileStorageService fileStorageService,
            IOutputPort outputPort)
        {
            this._incidentReportContext = incidentReportContext;
            this._applicantContext = userContext;
            this._fileStorageService = fileStorageService;
            this._outputPort = outputPort;
        }

        public async Task<Unit> Handle(CreateDraftApplicationInput input, CancellationToken cancellationToken)
        {
            try
            {
                var draftIncidentVerificationApplication = this.CreateDraft(input);

                if (this.IfAddedAttachmentsExists(input))
                {
                    var files = await this.UploadFilesToStorage(input);
                    this.AddUploadedFilesAsAttachments(draftIncidentVerificationApplication, files);
                }

                await this._incidentReportContext.DraftIncidentVerificationApplication.AddAsync(draftIncidentVerificationApplication);

                this.BuildOutput(draftIncidentVerificationApplication);
            }
            catch (BusinessRuleValidationException ex)
            {
                this._outputPort.WriteBusinessRuleError(ex.ToString());
            }
            catch (ApplicationLayerException ex)
            {
                this._outputPort.WriteBusinessRuleError(ex.ToString());
            }

            return Unit.Value;
        }

        private DraftApplication CreateDraft(CreateDraftApplicationInput request)
        {
            return new DraftApplication(
                new ContentOfApplication(request.Title, request.Description),
                request.IncidentType,
                new EmployeeId(this._applicantContext.UserId),
                new SuspiciousEmployees(request.SuspiciousEmployees.Select(x => new EmployeeId(x)))
                );
        }

        private bool IfAddedAttachmentsExists(CreateDraftApplicationInput request)
        {
            return request.Attachments != null && request.Attachments.Any();
        }

        private Task<List<UploadedFile>> UploadFilesToStorage(CreateDraftApplicationInput request)
        {
            return this._fileStorageService.UploadFiles(request.Attachments);
        }

        private void AddUploadedFilesAsAttachments(DraftApplication draftApplication, List<UploadedFile> files)
        {
            var attachments = files.Select(x => new IncidentVerificationApplicationAttachment(new FileInfo(x.FileName), new StorageId(x.StorageId)));
            draftApplication.AddAttachments(attachments);
        }

        private void BuildOutput(DraftApplication draftApplication)
        {
            var createDraftApplicationOutput = new CreateDraftApplicationOutput(draftApplication);
            this._outputPort.Standard(createDraftApplicationOutput);
        }
    }
}
