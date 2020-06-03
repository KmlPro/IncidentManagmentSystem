using System.Collections.Generic;
using BuildingBlocks.Domain.Abstract;
using IncidentReport.Domain.IncidentVerificationApplications.Enums;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;

namespace IncidentReport.Domain.IncidentVerificationApplications.Events
{
    public class DraftApplicationUpdatedDomainEvent : DomainEvent
    {
        public DraftApplicationId Id { get; set; }
        public ContentOfApplication ContentOfApplication { get; }
        public IncidentType? IncidentType { get; }
        public List<SuspiciousEmployee> SuspiciousEmployees { get; }

        public DraftApplicationUpdatedDomainEvent(DraftApplicationId id, ContentOfApplication contentOfApplication, IncidentType? incidentType, List<SuspiciousEmployee> suspiciousEmployees)
        {
            this.Id = id;
            this.ContentOfApplication = contentOfApplication;
            this.IncidentType = incidentType;
            this.SuspiciousEmployees = suspiciousEmployees;
        }
    }
}
