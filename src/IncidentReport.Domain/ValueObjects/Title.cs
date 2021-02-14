using BuildingBlocks.Domain.Abstract;
using Dawn;

namespace IncidentReport.Domain.ValueObjects
{
    public class Title : ValueObject
    {
        public string Value { get; }

        public Title(string value)
        {
            Guard.Argument(value).NotEmpty().MinLength(10).MaxLength(100);
            this.Value = value;
        }
    }
}
