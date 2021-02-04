using InitialIncidentVerification.Domain.ValueObjects;

namespace InitialIncidentVerification.Domain.Aggregates
{
    public class IncidentApplication
    {
        public IncidentApplication(IncidentApplicationId id, ApplicationNumber applicationNumber)
        {
            this.Id = id;
            this.ApplicationNumber = applicationNumber;
        }

        public IncidentApplicationId Id { get; }
        public ApplicationNumber ApplicationNumber { get; }

        public static IncidentApplication Create(ApplicationNumber applicationNumber)
        {
            var id = IncidentApplicationId.Create();
            return new IncidentApplication(id, applicationNumber);
        }
    }
}
