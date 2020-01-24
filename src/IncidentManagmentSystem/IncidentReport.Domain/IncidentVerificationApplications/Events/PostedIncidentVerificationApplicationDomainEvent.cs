using System;
using BuildingBlocks.Domain.Abstract;
using IncidentReport.Domain.IncidentVerificationApplications.Enums;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;
using IncidentReport.Domain.Users;

namespace IncidentReport.Domain.IncidentVerificationApplications.Events
{
    public class PostedIncidentVerificationApplicationDomainEvent : DomainEvent
    {
        public PostedApplicationId Id { get; }
        public ApplicationNumber ApplicationNumber { get; }
        public ContentOfApplication ContentOfApplication { get; }
        public IncidentType IncidentType { get; }
        public DateTime PostDate { get; }
        public UserId ApplicantId { get; }
        public SuspiciousEmployees SuspiciousEmployees { get; }
        public IncidentVerificationApplicationAttachments IncidentVerificationApplicationAttachments { get; }

        public PostedIncidentVerificationApplicationDomainEvent(
            PostedApplicationId id,
            ApplicationNumber applicationNumber,
            ContentOfApplication contentOfApplication,
            IncidentType incidentType,
            UserId applicantId,
            SuspiciousEmployees suspiciousEmployees,
            IncidentVerificationApplicationAttachments incidentVerificationApplicationAttachments,
            DateTime postDate)
        {
            this.Id = id;
            this.ContentOfApplication = contentOfApplication;
            this.IncidentType = incidentType;
            this.ApplicantId = applicantId;
            this.SuspiciousEmployees = suspiciousEmployees;
            this.ApplicationNumber = applicationNumber;
            this.IncidentVerificationApplicationAttachments = incidentVerificationApplicationAttachments;
            this.PostDate = postDate;
        }
    }
}
