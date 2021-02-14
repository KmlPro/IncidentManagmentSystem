using BuildingBlocks.Domain.Abstract;
using Dawn;

namespace IncidentReport.Domain.ValueObjects
{
    public class Content : ValueObject
    {
        public Content(string value)
        {
            Guard.Argument(value).NotEmpty().MinLength(10).MaxLength(100);
            this.Value = value;
        }

        public string Value { get; }
    }
}
