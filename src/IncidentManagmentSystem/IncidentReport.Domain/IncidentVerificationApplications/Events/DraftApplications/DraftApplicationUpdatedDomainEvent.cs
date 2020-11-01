using BuildingBlocks.Domain.Abstract;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;

namespace IncidentReport.Domain.IncidentVerificationApplications.Events.DraftApplications
{
    public class DraftApplicationUpdatedDomainEvent : DomainEvent
    {
        public DraftApplicationUpdatedDomainEvent(DraftApplicationId id, ContentOfApplication contentOfApplication,
            IncidentType incidentType): base(id.Value.ToString())
        {
            this.Id = id;
            this.ContentOfApplication = contentOfApplication;
            this.IncidentType = incidentType;
        }

        public DraftApplicationId Id { get; set; }
        public ContentOfApplication ContentOfApplication { get; }
        public IncidentType IncidentType { get; }
    }
}
