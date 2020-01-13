using BuildingBlocks.Domain.Abstract;

namespace IncidentReport.Domain.IncidentVerificationApplications.ValueObjects
{
    public class ApplicationNumber : ValueObject
    {
        public string Value { get; }

        private ApplicationNumber(string value)
        {
            this.Value = value;
        }

        public static ApplicationNumber Create(string value)
        {
            return new ApplicationNumber(value);
        }
    }
}
