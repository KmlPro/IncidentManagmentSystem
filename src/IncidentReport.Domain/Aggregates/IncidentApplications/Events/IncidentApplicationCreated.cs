using BuildingBlocks.Domain.Abstract;

namespace IncidentReport.Domain.Aggregates.IncidentApplications.Events
{
    public class IncidentApplicationCreated : DomainEvent
    {
        public IncidentApplicationCreated(IncidentApplication application) : base(application.Id.Value.ToString())
        {
            this.IncidentApplication = application;
        }

        public IncidentApplication IncidentApplication { get; }
    }
}
