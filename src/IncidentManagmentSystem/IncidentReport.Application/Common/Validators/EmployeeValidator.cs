using FluentValidation;
using IncidentReport.Domain.Employees;
using IncidentReport.Domain.Employees.ValueObjects;

namespace IncidentReport.Application.Common.Validators
{
    public class EmployeeValidator : AbstractValidator<EmployeeId>
    {
        private IEmployeeRepository _employeeRepository;

        public EmployeeValidator(IEmployeeRepository _employeeRepository) {
            RuleFor(x => x)
                .Must(id => this._employeeRepository.IsExists(id))
                .WithMessage("Employee not exists");
        }
    }
}
