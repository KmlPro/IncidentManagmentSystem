using FluentValidation;
using IncidentReport.Application.Boundaries.CreateDraftApplications;
using IncidentReport.Application.Common.Validators;
using IncidentReport.Application.Files;
using IncidentReport.Domain.Employees.ValueObjects;

namespace IncidentReport.Application.UseCases.CreateDraftApplications
{
    public class CreateDraftApplicationUseCaseValidator : AbstractValidator<CreateDraftApplicationInput>
    {
        public CreateDraftApplicationUseCaseValidator(IValidator<EmployeeId> employeeValidator,
            IValidator<ContentToValidate> contentValidator, IValidator<TitleToValidate> titleValidator,
            IValidator<IncidentTypeToValidate> incidentTypeValidator,IValidator<FileData> fileDataValidator)
        {
            this.RuleFor(input => input.Title).Transform(x => new TitleToValidate(x)).SetValidator(titleValidator);
            this.RuleFor(input => input.Description).Transform(x => new ContentToValidate(x))
                .SetValidator(contentValidator);
            this.RuleFor(input => input.IncidentType).Transform(x => new IncidentTypeToValidate(x))
                .SetValidator(incidentTypeValidator);
            this.RuleForEach(input => input.SuspiciousEmployees).Transform(x => new EmployeeId(x))
                .SetValidator(employeeValidator);
            this.RuleForEach(input => input.Attachments)
                .SetValidator(fileDataValidator);
        }

        public CreateDraftApplicationUseCaseValidator()
        {

        }
    }
}
