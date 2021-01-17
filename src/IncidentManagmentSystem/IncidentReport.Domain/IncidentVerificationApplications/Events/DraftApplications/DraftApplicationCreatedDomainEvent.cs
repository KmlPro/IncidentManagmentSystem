using System.Collections.Generic;
using BuildingBlocks.Domain.Abstract;
using IncidentReport.Domain.Employees.ValueObjects;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;

namespace IncidentReport.Domain.IncidentVerificationApplications.Events.DraftApplications
{
    public class DraftApplicationCreatedDomainEvent : DomainEvent
    {
        public DraftApplicationCreatedDomainEvent(DraftApplicationId id, ContentOfApplication contentOfApplication,
            IncidentType incidentType, EmployeeId applicantId, List<EmployeeId> suspiciousEmployees): base(id.Value.ToString())
        {
            this.Id = id;
            this.ContentOfApplication = contentOfApplication;
            this.IncidentType = incidentType;
            this.ApplicantId = applicantId;
            this.SuspiciousEmployees = suspiciousEmployees;
        }

        public DraftApplicationId Id { get; }
        public ContentOfApplication ContentOfApplication { get; }
        public IncidentType IncidentType { get; }
        public EmployeeId ApplicantId { get; }
        public List<EmployeeId> SuspiciousEmployees { get; }
    }
}
