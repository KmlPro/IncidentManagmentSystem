using System.Collections.Generic;
using BuildingBlocks.Domain.Abstract;
using IncidentReport.Domain.Employees.ValueObjects;
using IncidentReport.Domain.IncidentVerificationApplications.Enums;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;

namespace IncidentReport.Domain.IncidentVerificationApplications.Events
{
    public class DraftApplicationCreatedDomainEvent : DomainEvent
    {
        public DraftApplicationId Id { get; }
        public ContentOfApplication ContentOfApplication { get; }
        public IncidentType? IncidentType { get; }
        public EmployeeId ApplicantId { get; }
        public List<SuspiciousEmployee> SuspiciousEmployees { get; }

        public DraftApplicationCreatedDomainEvent(DraftApplicationId id, ContentOfApplication contentOfApplication, IncidentType? incidentType, EmployeeId applicantId, List<SuspiciousEmployee> suspiciousEmployees)
        {
            this.Id = id;
            this.ContentOfApplication = contentOfApplication;
            this.IncidentType = incidentType;
            this.ApplicantId = applicantId;
            this.SuspiciousEmployees = suspiciousEmployees;
        }
    }
}
