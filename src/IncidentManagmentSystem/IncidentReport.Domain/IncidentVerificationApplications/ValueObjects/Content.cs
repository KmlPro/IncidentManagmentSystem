using BuildingBlocks.Domain.Abstract;
using Dawn;

namespace IncidentReport.Domain.IncidentVerificationApplications.ValueObjects
{
    public class Content : ValueObject
    {
        public Content(string value)
        {
            Guard.Argument(value).NotEmpty();
            this.Value = value;
        }

        public string Value { get; }

        private Content()
        {
        }
    }
}
