using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BuildingBlocks.Application;
using BuildingBlocks.Application.Abstract;
using BuildingBlocks.Domain.Abstract;
using IncidentReport.Application.Boundaries.PostApplicationUseCase;
using IncidentReport.Application.Factories;
using IncidentReport.Application.Files;
using IncidentReport.Domain.IncidentVerificationApplications;
using IncidentReport.Domain.IncidentVerificationApplications.DraftApplications;
using IncidentReport.Domain.IncidentVerificationApplications.IncidentApplications;
using IncidentReport.Domain.IncidentVerificationApplications.IncidentApplications.States;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;

namespace IncidentReport.Application.UseCases
{
    public class PostApplicationUseCase : IUseCase
    {
        private readonly IFileStorageService _fileStorageService;
        private readonly IIncidentApplicationRepository _incidentApplicationRepository;
        private readonly IDraftApplicationRepository _draftApplicationRepository;
        private readonly IOutputPort _outputPort;
        private readonly AttachmentsFactory _attachmentsFactory;
        private readonly IncidentApplicationFactory _incidentApplicationFactory;

        public PostApplicationUseCase(IIncidentApplicationRepository incidentApplicationRepository,
            IDraftApplicationRepository draftApplicationRepository,
            ICurrentUserContext userContext,
            IFileStorageService fileStorageService,
            IOutputPort outputPort)
        {
            this._incidentApplicationRepository = incidentApplicationRepository;
            this._draftApplicationRepository = draftApplicationRepository;
            this._fileStorageService = fileStorageService;
            this._outputPort = outputPort;
            this._attachmentsFactory = new AttachmentsFactory();
            this._incidentApplicationFactory = new IncidentApplicationFactory(userContext);
        }

        //kbytner 06.08.2020 - add rollback uploaded attachments
        public async Task<IOutputPort> Handle(PostApplicationInput input, CancellationToken cancellationToken)
        {
            try
            {
                var attachments = new List<Attachment>();

                if (this.IfAddedAttachmentsExists(input))
                {
                    var files = await this.UploadFilesToStorage(input);
                    attachments = this._attachmentsFactory.CreateAttachments(files);
                }

                var incidentApplication = this._incidentApplicationFactory.CreateApplication(input, attachments);
                var postedIncidentApplication = incidentApplication.Post();

                await this._incidentApplicationRepository.Create(postedIncidentApplication);

                if (this.CreatedFromDraft(input))
                {
                    this._draftApplicationRepository.Delete(new DraftApplicationId(input.DraftApplicationId.Value));
                }

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

        private bool CreatedFromDraft(PostApplicationInput input)
        {
            return input.DraftApplicationId.HasValue;
        }

        private bool IfAddedAttachmentsExists(PostApplicationInput request)
        {
            return request.Attachments != null && request.Attachments.Any();
        }

        private Task<List<UploadedFile>> UploadFilesToStorage(PostApplicationInput request)
        {
            return this._fileStorageService.UploadFiles(request.Attachments);
        }

        private void BuildOutput(PostedIncidentApplication postedIncidentApplication)
        {
            var postApplicationOutput = new PostApplicationOutput(postedIncidentApplication);
            this._outputPort.Standard(postApplicationOutput);
        }
    }
}
