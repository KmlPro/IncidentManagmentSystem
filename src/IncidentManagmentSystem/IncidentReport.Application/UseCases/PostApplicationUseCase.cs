using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BuildingBlocks.Application;
using BuildingBlocks.Application.Abstract;
using BuildingBlocks.Domain.Abstract;
using IncidentReport.Application.Boundaries.PostApplicationUseCase;
using IncidentReport.Application.Files;
using IncidentReport.Domain.Employees.ValueObjects;
using IncidentReport.Domain.IncidentVerificationApplications;
using IncidentReport.Domain.IncidentVerificationApplications.Applications.States;
using IncidentReport.Domain.IncidentVerificationApplications.IncidentApplications;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;

namespace IncidentReport.Application.UseCases
{
    // kbytner 05.08.2020 - add remove draft if is in input
    public class PostApplicationUseCase : IUseCase
    {
        private readonly ICurrentUserContext _applicantContext;
        private readonly IFileStorageService _fileStorageService;
        private readonly IIncidentApplicationRepository _incidentApplicationRepository;
        private readonly IOutputPort _outputPort;

        public PostApplicationUseCase(IIncidentApplicationRepository incidentApplicationRepository,
            ICurrentUserContext userContext,
            IFileStorageService fileStorageService,
            IOutputPort outputPort)
        {
            this._incidentApplicationRepository = incidentApplicationRepository;
            this._applicantContext = userContext;
            this._fileStorageService = fileStorageService;
            this._outputPort = outputPort;
        }

        public async Task<IOutputPort> Handle(PostApplicationInput input, CancellationToken cancellationToken)
        {
            try
            {
                var attachments = new List<Attachment>();

                if (this.IfAddedAttachmentsExists(input))
                {
                    var files = await this.UploadFilesToStorage(input);
                    attachments = this.CreateAttachments(files);
                }

                var incidentApplication = this.CreateApplication(input, attachments);
                var postedIncidentApplication = incidentApplication.Post();

                await this._incidentApplicationRepository.Create(postedIncidentApplication);
                this.BuildOutput(postedIncidentApplication);
            }
            catch (BusinessRuleValidationException ex)
            {
                this._outputPort.WriteBusinessRuleError(ex.ToString());
            }
            catch (ApplicationLayerException ex)
            {
                this._outputPort.WriteBusinessRuleError(ex.ToString());
            }

            return this._outputPort;
        }

        private bool IfAddedAttachmentsExists(PostApplicationInput request)
        {
            return request.Attachments != null && request.Attachments.Any();
        }

        private Task<List<UploadedFile>> UploadFilesToStorage(PostApplicationInput request)
        {
            return this._fileStorageService.UploadFiles(request.Attachments);
        }

        private List<Attachment> CreateAttachments(List<UploadedFile> files)
        {
            return files.Select(x => new Attachment(new FileInfo(x.FileName), new StorageId(x.StorageId)))
                .ToList();
        }

        private CreatedIncidentApplication CreateApplication(PostApplicationInput request, List<Attachment> attachments)
        {
            return IncidentApplication.Create(
                new ContentOfApplication(request.Title, request.Description),
                new IncidentType(request.IncidentType),
                new EmployeeId(this._applicantContext.UserId),
                new List<EmployeeId>(
                    request.SuspiciousEmployees.Select(x => new EmployeeId(x))),
                attachments);
        }

        private void BuildOutput(PostedIncidentApplication postedIncidentApplication)
        {
            var postApplicationOutput = new PostApplicationOutput(postedIncidentApplication);
            this._outputPort.Standard(postApplicationOutput);
        }
    }
}
