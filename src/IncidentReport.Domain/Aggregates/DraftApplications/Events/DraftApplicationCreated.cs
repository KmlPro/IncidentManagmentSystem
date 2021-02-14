using System.Collections.Generic;
using BuildingBlocks.Domain.Abstract;
using IncidentReport.Domain.Entities.Employees.ValueObjects;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;
using IncidentReport.Domain.ValueObjects;

namespace IncidentReport.Domain.Aggregates.DraftApplications.Events
{
    public class DraftApplicationCreated : DomainEvent
    {
        public DraftApplicationCreated(DraftApplicationId id, Content content,
            IncidentType incidentType, EmployeeId applicantId, List<SuspiciousEmployee> suspiciousEmployees): base(id.Value.ToString())
        {
            this.Id = id;
            this.Content = content;
            this.IncidentType = incidentType;
            this.ApplicantId = applicantId;
            this.SuspiciousEmployees = suspiciousEmployees;
        }

        public DraftApplicationId Id { get; }
        public Content Content { get; }
        public IncidentType IncidentType { get; }
        public EmployeeId ApplicantId { get; }
        public List<SuspiciousEmployee> SuspiciousEmployees { get; }
    }
}
