using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BuildingBlocks.Application.ValidationErrors;
using BuildingBlocks.Domain.Abstract;
using FluentValidation;
using IncidentReport.Application.Boundaries.UpdateDraftApplications;
using IncidentReport.Application.Files;
using IncidentReport.Domain.Employees.ValueObjects;
using IncidentReport.Domain.IncidentVerificationApplications.DraftApplications;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;

namespace IncidentReport.Application.UseCases.UpdateDraftApplications
{
    public class UpdateDraftApplicationUseCase : IUseCase
    {
        private readonly IDraftApplicationRepository _draftApplicationRepository;
        private readonly IOutputPort _outputPort;
        private readonly UpdateAttachments _updateAttachments;
        private readonly IValidator<UpdateDraftApplicationInput> _validator;

        public UpdateDraftApplicationUseCase(IDraftApplicationRepository draftApplicationRepository,
            IFileStorageService fileStorageService,
            IOutputPort outputPort,
            IValidator<UpdateDraftApplicationInput> validator)
        {
            this._draftApplicationRepository = draftApplicationRepository;
            this._outputPort = outputPort;
            this._updateAttachments = new UpdateAttachments(fileStorageService);
            this._validator = validator;
        }

        public async Task<IOutputPort> Handle(UpdateDraftApplicationInput input, CancellationToken cancellationToken)
        {
            try
            {
                await this._validator.ValidateAndThrowAsync(input, cancellationToken);
                var draftApplication =
                    await this._draftApplicationRepository.GetById(new DraftApplicationId(input.DraftApplicationId),
                        cancellationToken);

                this.UpdateApplicationData(draftApplication, input);
                await this._updateAttachments.Handle(draftApplication, input);

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
            var employees = this.GetEmployees(request);
            draftApplication.Update(
                new ContentOfApplication(request.Title, request.Description),
                new IncidentType(request.IncidentType),
                employees);
        }

        private List<EmployeeId> GetEmployees(UpdateDraftApplicationInput input)
        {
            return input.SuspiciousEmployees.Select(x => new EmployeeId(x)).ToList();
        }
    }
}
