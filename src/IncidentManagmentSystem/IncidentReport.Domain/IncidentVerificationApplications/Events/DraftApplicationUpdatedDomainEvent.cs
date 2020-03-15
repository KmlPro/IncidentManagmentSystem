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
        public SuspiciousEmployees SuspiciousEmployees { get; }
        public IncidentVerificationApplicationAttachments IncidentVerificationApplicationAttachments { get; }

        public DraftApplicationUpdatedDomainEvent(DraftApplicationId id, ContentOfApplication contentOfApplication, IncidentType? incidentType, SuspiciousEmployees suspiciousEmployees, IncidentVerificationApplicationAttachments incidentVerificationApplicationAttachments)
        {
            this.Id = id;
            this.ContentOfApplication = contentOfApplication;
            this.IncidentType = incidentType;
            this.SuspiciousEmployees = suspiciousEmployees;
            this.IncidentVerificationApplicationAttachments = incidentVerificationApplicationAttachments;
        }
    }
}
