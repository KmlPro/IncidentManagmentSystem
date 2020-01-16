using System;
using BuildingBlocks.Domain;
using BuildingBlocks.Domain.Abstract;
using BuildingBlocks.Domain.Interfaces;
using IncidentReport.Domain.IncidentVerificationApplications.Enums;
using IncidentReport.Domain.IncidentVerificationApplications.Events;
using IncidentReport.Domain.IncidentVerificationApplications.Rules.ApplicantCannotBeSuspectRule;
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
        public UserId ApplicantId { get; }
        public SuspiciousEmployees SuspiciousEmployees { get; }
        public UserId CreatorId { get; }

        public static PostedIncidentVerificationApplication Create(ContentOfApplication contentOfApplication, IncidentType incidentType, UserId applicantId, SuspiciousEmployees suspiciousEmployees, UserId creatorId)
        {
            return new PostedIncidentVerificationApplication(contentOfApplication, incidentType, SystemClock.Now, applicantId, suspiciousEmployees, creatorId);
        }

        private PostedIncidentVerificationApplication(ContentOfApplication contentOfApplication, IncidentType incidentType, DateTime postDate, UserId applicantId, SuspiciousEmployees suspiciousEmployees, UserId creatorId)
        {
            this.CheckRule(new ApplicantCannotBeSuspectRule(suspiciousEmployees, applicantId));

            this.ContentOfApplication = contentOfApplication;
            this.IncidentType = incidentType;
            this.ApplicantId = applicantId;
            this.SuspiciousEmployees = suspiciousEmployees;
            this.PostDate = postDate;
            this.CreatorId = creatorId;

            this.AddDomainEvent(new PostedIncidentVerificationApplicationDomainEvent(this.ContentOfApplication, this.IncidentType, this.PostDate, this.ApplicantId, this.SuspiciousEmployees, this.CreatorId));
        }
    }
}
