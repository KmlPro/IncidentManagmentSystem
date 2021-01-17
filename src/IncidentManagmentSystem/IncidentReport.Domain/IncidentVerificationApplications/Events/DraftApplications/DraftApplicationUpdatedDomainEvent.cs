using System.Collections.Generic;
using BuildingBlocks.Domain.Abstract;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;

namespace IncidentReport.Domain.IncidentVerificationApplications.Events.DraftApplications
{
    public class DraftApplicationUpdatedDomainEvent : DomainEvent
    {
        public DraftApplicationUpdatedDomainEvent(DraftApplicationId id, Content content,
            IncidentType incidentType, List<SuspiciousEmployee> suspiciousEmployees): base(id.Value.ToString())
        {
            this.Id = id;
            this.Content = content;
            this.IncidentType = incidentType;
            this.SuspiciousEmployees = suspiciousEmployees;
        }

        public DraftApplicationId Id { get; }
        public Content Content { get; }
        public IncidentType IncidentType { get; }
        public List<SuspiciousEmployee> SuspiciousEmployees { get; }
    }
}
