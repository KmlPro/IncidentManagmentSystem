using BuildingBlocks.Domain.Abstract;

namespace IncidentReport.Domain.IncidentVerificationApplications.ValueObjects
{
    public class ApplicationIdValue : ValueObject
    {
        public long Value { get; }

        private ApplicationIdValue(long value)
        {
            this.Value = value;
        }

        public static ApplicationIdValue Create(long value)
        {
            return new ApplicationIdValue(value);
        }
    }
}
