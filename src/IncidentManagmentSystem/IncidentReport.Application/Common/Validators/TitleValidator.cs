using FluentValidation;

namespace IncidentReport.Application.Common.Validators
{
    public class TitleValidator : AbstractValidator<TitleToValidate>
    {
        public TitleValidator() {
            this.RuleFor(input => input).Transform(x=> x.Title).MinimumLength(10).MaximumLength(100);
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
