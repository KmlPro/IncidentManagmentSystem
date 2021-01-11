using BuildingBlocks.Domain.Abstract;
using IncidentReport.Domain.IncidentVerificationApplications.IncidentApplications;

namespace IncidentReport.Domain.IncidentVerificationApplications.Events.Applications
{
    public class ApplicationCreatedDomainEvent : DomainEvent
    {
        public ApplicationCreatedDomainEvent(IncidentApplication application) : base(application.Id.Value.ToString())
        {
            this.IncidentApplication = application;
        }

        public IncidentApplication IncidentApplication { get; }
    }
}
