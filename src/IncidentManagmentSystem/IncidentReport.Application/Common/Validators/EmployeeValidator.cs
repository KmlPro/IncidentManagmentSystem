using FluentValidation;
using IncidentReport.Domain.Entities.Employees;
using IncidentReport.Domain.Entities.Employees.ValueObjects;

namespace IncidentReport.Application.Common.Validators
{
    public class EmployeeValidator : AbstractValidator<EmployeeId>
    {
        public EmployeeValidator(IEmployeeRepository _employeeRepository) {
            this.RuleFor(x => x)
                .Must(_employeeRepository.IsExists)
                .WithMessage("Employee not exists");
        }
    }
}
