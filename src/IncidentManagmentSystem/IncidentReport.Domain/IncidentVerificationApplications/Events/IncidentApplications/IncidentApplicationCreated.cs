using BuildingBlocks.Domain.Abstract;
using IncidentReport.Domain.IncidentVerificationApplications.IncidentApplications;

namespace IncidentReport.Domain.IncidentVerificationApplications.Events.IncidentApplications
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
