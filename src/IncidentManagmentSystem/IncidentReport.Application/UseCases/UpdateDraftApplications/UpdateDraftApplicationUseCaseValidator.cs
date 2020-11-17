using FluentValidation;
using IncidentReport.Application.Boundaries.UpdateDraftApplications;
using IncidentReport.Application.Common.Validators;
using IncidentReport.Domain.Employees.ValueObjects;

namespace IncidentReport.Application.UseCases.UpdateDraftApplications
{
    public class UpdateDraftApplicationUseCaseValidator : AbstractValidator<UpdateDraftApplicationInput>
    {
        public UpdateDraftApplicationUseCaseValidator(IValidator<EmployeeId> employeeIValidator,
            IValidator<ContentToValidate> contentValidator, IValidator<TitleToValidate> titleValidator,
            IValidator<IncidentTypeToValidate> incidentTypeValidator)
        {
            this.RuleFor(input => input.Title).Transform(x => new TitleToValidate(x)).SetValidator(titleValidator);
            this.RuleFor(input => input.Description).Transform(x => new ContentToValidate(x))
                .SetValidator(contentValidator);
            this.RuleFor(input => input.IncidentType).Transform(x => new IncidentTypeToValidate(x))
                .SetValidator(incidentTypeValidator);
            this.RuleForEach(input => input.SuspiciousEmployees).Transform(x => new EmployeeId(x))
                .SetValidator(employeeIValidator);
        }
    }
}
