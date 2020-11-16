using FluentValidation;
using IncidentReport.Application.Boundaries.CreateDraftApplications;
using IncidentReport.Domain.Employees.ValueObjects;

namespace IncidentReport.Application.UseCases.CreateDraftApplications
{
    public class CreateDraftApplicationUseCaseValidator : AbstractValidator<CreateDraftApplicationInput>
    {
        public CreateDraftApplicationUseCaseValidator(IValidator<EmployeeId> employeeIValidator) {
            RuleFor(input => input.Title).NotEmpty();
            RuleFor(input => input.Description).NotEmpty();
            RuleForEach(input => input.SuspiciousEmployees).Transform(x=> new EmployeeId(x)).SetValidator(employeeIValidator);
        }
    }
}
