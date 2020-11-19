using FluentValidation;
using IncidentReport.Domain.Employees;
using IncidentReport.Domain.Employees.ValueObjects;

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
