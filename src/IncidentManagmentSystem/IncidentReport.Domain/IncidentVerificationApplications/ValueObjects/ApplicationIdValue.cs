using BuildingBlocks.Domain;

namespace IncidentReport.Domain.IncidentVerificationApplications.ValueObjects
{
    public class ApplicationIdValue : IValueObject
    {
        public long Value { get; }

        public ApplicationIdValue(long value)
        {
            this.Value = value;
        }
    }
}
