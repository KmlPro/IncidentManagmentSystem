using BuildingBlocks.Domain;

namespace IncidentReport.Domain.IncidentVerificationApplications.ValueObjects
{
    public class ApplicationNumber : IValueObject
    {
        public string Value { get; }

        public ApplicationNumber(string value)
        {
            this.Value = value;
        }
    }
}
