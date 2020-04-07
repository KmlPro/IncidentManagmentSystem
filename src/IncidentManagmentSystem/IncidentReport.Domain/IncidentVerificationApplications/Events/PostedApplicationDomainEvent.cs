using System;
using System.Collections.Generic;
using BuildingBlocks.Domain.Abstract;
using IncidentReport.Domain.Employees.ValueObjects;
using IncidentReport.Domain.IncidentVerificationApplications.Enums;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;

namespace IncidentReport.Domain.IncidentVerificationApplications.Events
{
    public class PostedApplicationDomainEvent : DomainEvent
    {
        public PostedApplicationId Id { get; }
        public ApplicationNumber ApplicationNumber { get; }
        public ContentOfApplication ContentOfApplication { get; }
        public IncidentType IncidentType { get; }
        public DateTime PostDate { get; }
        public EmployeeId ApplicantId { get; }
        public SuspiciousEmployees SuspiciousEmployees { get; }
        public List<Attachment> Attachments { get; }

        public PostedApplicationDomainEvent(
            PostedApplicationId id,
            ApplicationNumber applicationNumber,
            ContentOfApplication contentOfApplication,
            IncidentType incidentType,
            EmployeeId applicantId,
            SuspiciousEmployees suspiciousEmployees,
            List<Attachment> attachments,
            DateTime postDate)
        {
            this.Id = id;
            this.ContentOfApplication = contentOfApplication;
            this.IncidentType = incidentType;
            this.ApplicantId = applicantId;
            this.SuspiciousEmployees = suspiciousEmployees;
            this.ApplicationNumber = applicationNumber;
            this.Attachments = attachments;
            this.PostDate = postDate;
        }
    }
}
