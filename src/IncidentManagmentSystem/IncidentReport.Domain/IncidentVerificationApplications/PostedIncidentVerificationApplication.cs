using System;
using BuildingBlocks.Domain;
using BuildingBlocks.Domain.Abstract;
using BuildingBlocks.Domain.Interfaces;
using IncidentReport.Domain.IncidentVerificationApplications.Enums;
using IncidentReport.Domain.IncidentVerificationApplications.Events;
using IncidentReport.Domain.Users;

namespace IncidentReport.Domain.IncidentVerificationApplications
{
    public class PostedIncidentVerificationApplication : Entity, IAggregateRoot
    {
        public ApplicationId Id { get; }
        public string Title { get; }
        public string Content { get; }
        public IncidentType IncidentType { get; }
        public DateTime PostDate { get; }

        public static PostedIncidentVerificationApplication Create(string title, string content, IncidentType incidentType, UserId applicantId)
        {
            return new PostedIncidentVerificationApplication(title, content, incidentType, SystemClock.Now, applicantId);
        }

        private PostedIncidentVerificationApplication(string title, string content, IncidentType incidentType, DateTime postDate, UserId applicantId)
        {
            this.Title = title;
            this.Content = content;
            this.IncidentType = incidentType;
            this.PostDate = postDate;

            this.AddDomainEvent(new PostedIncidentVerificationApplicationDomainEvent(title, content, incidentType, postDate, applicantId));
        }
    }
}
