using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BuildingBlocks.Application;
using BuildingBlocks.Application.ValidationErrors;
using BuildingBlocks.Domain.Abstract;
using FluentValidation;
using IncidentReport.Application.Boundaries.CreateDraftApplications;
using IncidentReport.Application.Factories;
using IncidentReport.Application.Files;
using IncidentReport.Domain.IncidentVerificationApplications.DraftApplications;

namespace IncidentReport.Application.UseCases.CreateDraftApplications
{
    public class CreateDraftApplicationUseCase : IUseCase
    {
        private readonly IFileStorageService _fileStorageService;
        private readonly IOutputPort _outputPort;
        private readonly IDraftApplicationRepository _draftApplicationRepository;
        private readonly CreateDraftApplicationUseCaseValidator _validator;
        private readonly AttachmentsFactory _attachmentsFactory;
        private readonly DraftApplicationFactory _draftApplicationFactory;

        public CreateDraftApplicationUseCase(ICurrentUserContext userContext,
            IFileStorageService fileStorageService,
            IDraftApplicationRepository draftApplicationRepository,
            IOutputPort outputPort,
            CreateDraftApplicationUseCaseValidator validator)
        {
            this._draftApplicationRepository = draftApplicationRepository;
            this._fileStorageService = fileStorageService;
            this._outputPort = outputPort;
            this._attachmentsFactory = new AttachmentsFactory();
            this._draftApplicationFactory = new DraftApplicationFactory(userContext);
            this._validator = validator;
        }

        public async Task<IOutputPort> Handle(CreateDraftApplicationInput input, CancellationToken cancellationToken)
        {
            try
            {
                await this._validator.ValidateAndThrowAsync(input, cancellationToken);

                var draftApplication = this._draftApplicationFactory.Create(input);

                if (this.IfAddedAttachmentsExists(input))
                {
                    var files = await this.UploadFilesToStorage(input);
                    this.AddUploadedFilesAsAttachments(draftApplication, files);
                }

                await this._draftApplicationRepository.Create(draftApplication,
                    cancellationToken);

                this.BuildOutput(draftApplication);
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
            var attachments = this._attachmentsFactory.CreateAttachments(files);
            draftApplication.AddAttachments(attachments);
        }

        private void BuildOutput(DraftApplication draftApplication)
        {
            var createDraftApplicationOutput = new CreateDraftApplicationOutput(draftApplication);
            this._outputPort.Standard(createDraftApplicationOutput);
        }
    }
}
