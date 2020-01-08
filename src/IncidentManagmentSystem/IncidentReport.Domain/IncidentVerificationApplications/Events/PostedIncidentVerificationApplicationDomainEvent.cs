using System;
using BuildingBlocks.Domain;
using BuildingBlocks.Domain.Abstract;
using IncidentReport.Domain.IncidentVerificationApplications.Enums;
using IncidentReport.Domain.Users;

namespace IncidentReport.Domain.IncidentVerificationApplications.Events
{
    public class PostedIncidentVerificationApplicationDomainEvent : DomainEvent
    {
        public string Title { get; }
        public string Content { get; }
        public IncidentType IncidentType { get; }
        public DateTime PostDate { get; }
        public UserId ApplicantId { get; }

        public PostedIncidentVerificationApplicationDomainEvent(string title, string content, IncidentType incidentType, DateTime postDate, UserId applicantId)
        {
            this.Title = title;
            this.Content = content;
            this.IncidentType = incidentType;
            this.PostDate = postDate;
            this.ApplicantId = applicantId;
        }
    }
}
