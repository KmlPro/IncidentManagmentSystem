using System;
using System.Collections.Generic;
using BuildingBlocks.Domain.Abstract;
using IncidentReport.Domain.Employees.ValueObjects;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;

namespace IncidentReport.Domain.IncidentVerificationApplications.Events.Applications
{
    public class ApplicationCreatedDomainEvent : DomainEvent
    {
        public ApplicationCreatedDomainEvent(IncidentApplicationId id, ApplicationNumber applicationNumber,
            ContentOfApplication contentOfApplication, IncidentType incidentType, DateTime postDate,
            EmployeeId applicantId, List<SuspiciousEmployee> suspiciousEmployees, List<Attachment> attachments)
        {
            this.Id = id;
            this.ApplicationNumber = applicationNumber;
            this.ContentOfApplication = contentOfApplication;
            this.IncidentType = incidentType;
            this.PostDate = postDate;
            this.ApplicantId = applicantId;
            this.SuspiciousEmployees = suspiciousEmployees;
            this.Attachments = attachments;
        }

        public IncidentApplicationId Id { get; }
        public ApplicationNumber ApplicationNumber { get; }
        public ContentOfApplication ContentOfApplication { get; }
        public IncidentType IncidentType { get; }
        public DateTime PostDate { get; }
        public EmployeeId ApplicantId { get; }
        public List<SuspiciousEmployee> SuspiciousEmployees { get; }
        public List<Attachment> Attachments { get; }
    }
}
