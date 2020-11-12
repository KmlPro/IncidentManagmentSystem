using System.Threading;
using System.Threading.Tasks;
using BuildingBlocks.Application.ValidationErrors;
using BuildingBlocks.Domain.Abstract;
using FluentValidation;
using IncidentReport.Application.Boundaries.UpdateDraftApplications;
using IncidentReport.Application.Files;
using IncidentReport.Domain.IncidentVerificationApplications.DraftApplications;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;

namespace IncidentReport.Application.UseCases.UpdateDraftApplications
{
    public class UpdateDraftApplicationUseCase : IUseCase
    {
        private readonly IDraftApplicationRepository _draftApplicationRepository;
        private readonly IOutputPort _outputPort;
        private readonly UpdateSuspiciousEmployees _updateSuspiciousEmployees;
        private readonly UpdateAttachments _updateAttachments;

        public UpdateDraftApplicationUseCase(IDraftApplicationRepository draftApplicationRepository,
            IFileStorageService fileStorageService,
            IOutputPort outputPort)
        {
            this._draftApplicationRepository = draftApplicationRepository;
            this._outputPort = outputPort;
            this._updateAttachments = new UpdateAttachments(fileStorageService);
            this._updateSuspiciousEmployees = new UpdateSuspiciousEmployees();
        }

        public async Task<IOutputPort> Handle(UpdateDraftApplicationInput input, CancellationToken cancellationToken)
        {
            try
            {
                var draftApplication =
                    await this._draftApplicationRepository.GetById(new DraftApplicationId(input.DraftApplicationId), cancellationToken);

                this.UpdateApplicationData(draftApplication, input);
                await this._updateAttachments.Handle(draftApplication, input);
                this._updateSuspiciousEmployees.Handle(draftApplication, input);

                this._draftApplicationRepository.Update(draftApplication);
                this.BuildOutput();
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

        private void BuildOutput()
        {
            this._outputPort.Standard(new UpdateDraftApplicationOutput());
        }

        private void UpdateApplicationData(DraftApplication draftApplication, UpdateDraftApplicationInput request)
        {
            draftApplication.Update(
                new ContentOfApplication(request.Title, request.Description),
                new IncidentType(request.IncidentType));
        }
    }
}
