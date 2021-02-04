using System.Collections.Generic;
using BuildingBlocks.Domain.Abstract;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;
using IncidentReport.Domain.ValueObjects;

namespace IncidentReport.Domain.Aggregates.DraftApplications.Events
{
    public class DraftApplicationUpdated : DomainEvent
    {
        public DraftApplicationUpdated(DraftApplicationId id, Content content,
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
