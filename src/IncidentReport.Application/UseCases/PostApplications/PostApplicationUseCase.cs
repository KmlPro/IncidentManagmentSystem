using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BuildingBlocks.Application;
using BuildingBlocks.Application.ValidationErrors;
using BuildingBlocks.Domain.Abstract;
using FluentValidation;
using IncidentReport.Application.Boundaries.PostApplicationUseCase;
using IncidentReport.Application.Factories;
using IncidentReport.Application.Files;
using IncidentReport.Application.Services;
using IncidentReport.Domain.Aggregates.DraftApplications;
using IncidentReport.Domain.Aggregates.IncidentApplications;
using IncidentReport.Domain.Entities.Attachments;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;
using IncidentReport.Domain.ValueObjects;

namespace IncidentReport.Application.UseCases.PostApplications
{
    public class PostApplicationUseCase : IUseCase
    {
        private readonly IFileStorageService _fileStorageService;
        private readonly IIncidentApplicationRepository _incidentApplicationRepository;
        private readonly IDraftApplicationRepository _draftApplicationRepository;
        private readonly IOutputPort _outputPort;
        private readonly AttachmentsFactory _attachmentsFactory;
        private readonly IncidentApplicationFactory _incidentApplicationFactory;
        private readonly IValidator<PostApplicationInput> _validator;
        private readonly IEventProcessor _eventProcesor;

        public PostApplicationUseCase(IIncidentApplicationRepository incidentApplicationRepository,
            IDraftApplicationRepository draftApplicationRepository,
            ICurrentUserContext userContext,
            IFileStorageService fileStorageService,
            IOutputPort outputPort,
            IValidator<PostApplicationInput> validator, IEventProcessor eventProcesor)
        {
            this._incidentApplicationRepository = incidentApplicationRepository;
            this._draftApplicationRepository = draftApplicationRepository;
            this._fileStorageService = fileStorageService;
            this._outputPort = outputPort;
            this._attachmentsFactory = new AttachmentsFactory();
            this._incidentApplicationFactory = new IncidentApplicationFactory(userContext);
            this._validator = validator;
            this._eventProcesor = eventProcesor;
        }

        //kbytner 06.08.2020 - add rollback uploaded attachments
        public async Task<IOutputPort> Handle(PostApplicationInput input, CancellationToken cancellationToken)
        {
            try
            {
                await this._validator.ValidateAndThrowAsync(input, cancellationToken);
                var attachments = new List<Attachment>();

                if (this.IfAddedAttachmentsExists(input))
                {
                    var files = await this.UploadFilesToStorage(input);
                    attachments = this._attachmentsFactory.CreateAttachments(files);
                }

                var incidentApplication = this._incidentApplicationFactory.CreateApplication(input, attachments);

                await this._incidentApplicationRepository.Create(incidentApplication, cancellationToken);

                if (this.CreatedFromDraft(input))
                {
                    this._draftApplicationRepository.Delete(new DraftApplicationId(input.DraftApplicationId.Value));
                }

                await this._eventProcesor.Process(incidentApplication.DomainEvents, cancellationToken);

                this.BuildOutput(incidentApplication);
            }
            catch (BusinessRuleValidationException ex)
            {
                this._outputPort.WriteBusinessRuleError(ex.ToString());
            }
            catch (ValidationException ex)
            {
                this._outputPort.WriteInvalidInput(ex.MapToInvaliInputErrors());
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

        private void BuildOutput(IncidentApplication incidentApplication)
        {
            var postApplicationOutput = new PostApplicationOutput(incidentApplication.Id.Value);
            this._outputPort.Standard(postApplicationOutput);
        }
    }
}
