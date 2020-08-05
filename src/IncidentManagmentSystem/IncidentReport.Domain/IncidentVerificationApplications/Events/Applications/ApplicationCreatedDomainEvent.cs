using System;
using System.Collections.Generic;
using BuildingBlocks.Domain.Abstract;
using IncidentReport.Domain.Employees.ValueObjects;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;
using ApplicationId = IncidentReport.Domain.IncidentVerificationApplications.ValueObjects.ApplicationId;

namespace IncidentReport.Domain.IncidentVerificationApplications.Events.Applications
{
    public class ApplicationCreatedDomainEvent : DomainEvent
    {
        public ApplicationCreatedDomainEvent(ApplicationId id, ApplicationNumber applicationNumber,
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

        public ApplicationId Id { get; }
        public ApplicationNumber ApplicationNumber { get; }
        public ContentOfApplication ContentOfApplication { get; }
        public IncidentType IncidentType { get; }
        public DateTime PostDate { get; }
        public EmployeeId ApplicantId { get; }
        public List<SuspiciousEmployee> SuspiciousEmployees { get; }
        public List<Attachment> Attachments { get; }
    }
}
