using BuildingBlocks.Domain.Abstract;
using IncidentReport.Domain.Employees.ValueObjects;
using IncidentReport.Domain.IncidentVerificationApplications.Enums;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;

namespace IncidentReport.Domain.IncidentVerificationApplications.Events
{
    public class DraftIncidentVerificationApplicationCreatedDomainEvent : DomainEvent
    {
        public DraftApplicationId Id { get; }
        public ContentOfApplication ContentOfApplication { get; }
        public IncidentType? IncidentType { get; }
        public EmployeeId ApplicantId { get; }
        public SuspiciousEmployees SuspiciousEmployees { get; }

        public DraftIncidentVerificationApplicationCreatedDomainEvent(DraftApplicationId id, ContentOfApplication contentOfApplication, IncidentType? incidentType, EmployeeId applicantId, SuspiciousEmployees suspiciousEmployees)
        {
            this.Id = id;
            this.ContentOfApplication = contentOfApplication;
            this.IncidentType = incidentType;
            this.ApplicantId = applicantId;
            this.SuspiciousEmployees = suspiciousEmployees;
        }
    }
}
