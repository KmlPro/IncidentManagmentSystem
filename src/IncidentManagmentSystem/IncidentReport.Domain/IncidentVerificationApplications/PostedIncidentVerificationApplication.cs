using System;
using BuildingBlocks.Domain;
using BuildingBlocks.Domain.Abstract;
using BuildingBlocks.Domain.Interfaces;
using IncidentReport.Domain.IncidentVerificationApplications.Enums;
using IncidentReport.Domain.IncidentVerificationApplications.Events;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;
using IncidentReport.Domain.Users;

namespace IncidentReport.Domain.IncidentVerificationApplications
{
    public class PostedIncidentVerificationApplication : Entity, IAggregateRoot
    {
        public ApplicationId Id { get; }
        public ContentOfApplication ContentOfApplication { get; }
        public IncidentType IncidentType { get; }
        public DateTime PostDate { get; }

        public static PostedIncidentVerificationApplication Create(ContentOfApplication contentOfApplication, IncidentType incidentType, UserId applicantId)
        {
            return new PostedIncidentVerificationApplication(contentOfApplication, incidentType, SystemClock.Now, applicantId);
        }

        private PostedIncidentVerificationApplication(ContentOfApplication contentOfApplication, IncidentType incidentType, DateTime postDate, UserId applicantId)
        {
            this.ContentOfApplication = contentOfApplication;
            this.IncidentType = incidentType;
            this.PostDate = postDate;

            this.AddDomainEvent(new PostedIncidentVerificationApplicationDomainEvent(contentOfApplication, incidentType, postDate, applicantId));
        }
    }
}
