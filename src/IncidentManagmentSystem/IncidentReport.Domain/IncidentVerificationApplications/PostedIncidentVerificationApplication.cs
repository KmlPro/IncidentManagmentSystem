using System;
using BuildingBlocks.Domain;
using IncidentReport.Domain.IncidentVerificationApplications.Enums;
using IncidentReport.Domain.IncidentVerificationApplications.Events;

namespace IncidentReport.Domain.IncidentVerificationApplications
{
    public class PostedIncidentVerificationApplication : Entity, IAggregateRoot
    {
        public ApplicationId Id { get; }
        public string Title { get; }
        public string Content { get; }
        public IncidentType IncidentType { get; }
        public DateTime PostDate { get; }

        public static PostedIncidentVerificationApplication Create(string title, string content, IncidentType incidentType)
        {
            return new PostedIncidentVerificationApplication(title, content, incidentType, SystemClock.Now);
        }

        private PostedIncidentVerificationApplication(string title, string content, IncidentType incidentType, DateTime postDate)
        {
            this.Title = title;
            this.Content = content;
            this.IncidentType = incidentType;
            this.PostDate = postDate;

            this.AddDomainEvent(new PostedIncidentVerificationApplicationDomainEvent(title, content, incidentType, postDate));
        }
    }
}
