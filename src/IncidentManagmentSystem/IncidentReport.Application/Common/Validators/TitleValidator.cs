using FluentValidation;

namespace IncidentReport.Application.Common.Validators
{
    public class TitleValidator : AbstractValidator<ContentToValidate>
    {
        public TitleValidator() {
            this.RuleFor(input => input).Transform(x=> x.Content).MinimumLength(10).MaximumLength(100);
        }
    }

    public class TitleToValidate
    {
        public TitleToValidate(string title)
        {
            this.Title = title;
        }

        public string Title { get; }
    }
}
