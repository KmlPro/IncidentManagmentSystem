using BuildingBlocks.Domain.Abstract;

namespace IncidentReport.Domain.IncidentVerificationApplications.ValueObjects
{
    public class ApplicationIdValue : ValueObject
    {
        public long Value { get; }

        public ApplicationIdValue(long value)
        {
            this.Value = value;
        }
    }
}
