using FluentValidation;
using IncidentReport.Application.Boundaries.PostApplicationUseCase;
using IncidentReport.Application.Common.Validators;
using IncidentReport.Application.Files;
using IncidentReport.Domain.Entities.Employees.ValueObjects;

namespace IncidentReport.Application.UseCases.PostApplications
{
    public class PostApplicationUseCaseValidator : AbstractValidator<PostApplicationInput>
    {
        public PostApplicationUseCaseValidator(IValidator<EmployeeId> employeeIValidator,
            IValidator<ContentToValidate> contentValidator, IValidator<TitleToValidate> titleValidator,
            IValidator<IncidentTypeToValidate> incidentTypeValidator, IValidator<FileData> fileDataValidator)
        {
            this.RuleFor(input => input.Title).Transform(x => new TitleToValidate(x)).SetValidator(titleValidator);
            this.RuleFor(input => input.Content).Transform(x => new ContentToValidate(x))
                .SetValidator(contentValidator);
            this.RuleFor(input => input.IncidentType).Transform(x => new IncidentTypeToValidate(x))
                .SetValidator(incidentTypeValidator);
            this.RuleForEach(input => input.SuspiciousEmployees).Transform(x => new EmployeeId(x))
                .SetValidator(employeeIValidator);
            this.RuleForEach(input => input.Attachments)
                .SetValidator(fileDataValidator);
        }

        public PostApplicationUseCaseValidator()
        {

        }
    }
}
