using FluentValidation;

namespace IncidentReport.Application.Common.Validators
{
    public class ContentValidator : AbstractValidator<ContentToValidate>
    {
        public ContentValidator() {
            this.RuleFor(input => input).Transform(x=> x.Content).MinimumLength(10).MaximumLength(1000);
        }
    }

    public class ContentToValidate
    {
        public ContentToValidate(string content)
        {
            this.Content = content;
        }

        public string Content { get; }
    }
}
