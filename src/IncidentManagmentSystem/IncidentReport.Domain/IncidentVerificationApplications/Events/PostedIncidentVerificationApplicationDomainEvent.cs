using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.Domain;
using IncidentReport.Domain.IncidentVerificationApplications.Enums;

namespace IncidentReport.Domain.IncidentVerificationApplications.Events
{
    public class PostedIncidentVerificationApplicationDomainEvent : DomainEvent
    {
        public string Title { get; }
        public string Content { get; }
        public IncidentType IncidentType { get; }
        public DateTime PostDate { get; }

        public PostedIncidentVerificationApplicationDomainEvent(string title, string content, IncidentType incidentType, DateTime postDate)
        {
            this.Title = title;
            this.Content = content;
            this.IncidentType = incidentType;
            this.PostDate = postDate;
        }
    }
}
