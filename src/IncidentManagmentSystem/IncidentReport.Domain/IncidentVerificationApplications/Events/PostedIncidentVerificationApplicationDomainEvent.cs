using System;
using BuildingBlocks.Domain;
using BuildingBlocks.Domain.Abstract;
using IncidentReport.Domain.IncidentVerificationApplications.Enums;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;
using IncidentReport.Domain.Users;

namespace IncidentReport.Domain.IncidentVerificationApplications.Events
{
    public class PostedIncidentVerificationApplicationDomainEvent : DomainEvent
    {
        public ContentOfApplication ContentOfApplication { get; }
        public IncidentType IncidentType { get; }
        public DateTime PostDate { get; }
        public UserId ApplicantId { get; }

        public PostedIncidentVerificationApplicationDomainEvent(ContentOfApplication contentOfApplication, IncidentType incidentType, DateTime postDate, UserId applicantId)
        {
            this.ContentOfApplication = contentOfApplication;
            this.IncidentType = incidentType;
            this.PostDate = postDate;
            this.ApplicantId = applicantId;
        }
    }
}
