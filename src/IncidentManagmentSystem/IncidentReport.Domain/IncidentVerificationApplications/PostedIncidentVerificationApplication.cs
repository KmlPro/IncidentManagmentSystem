using System;
using System.Collections.Generic;
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
        public List<UserId> SuspiciousEmployees { get; }

        //kbytner 13.10 -- TO DO Move SystemClock to Application Layer
        public static PostedIncidentVerificationApplication Create(ContentOfApplication contentOfApplication, IncidentType incidentType, UserId applicantId, List<UserId> suspiciousEmployees)
        {
            return new PostedIncidentVerificationApplication(contentOfApplication, incidentType, SystemClock.Now, applicantId, suspiciousEmployees);
        }

        private PostedIncidentVerificationApplication(ContentOfApplication contentOfApplication, IncidentType incidentType, DateTime postDate, UserId applicantId, List<UserId> suspiciousEmployees)
        {
            this.ContentOfApplication = contentOfApplication;
            this.IncidentType = incidentType;
            this.PostDate = postDate;
            this.SuspiciousEmployees = suspiciousEmployees;

            this.AddDomainEvent(new PostedIncidentVerificationApplicationDomainEvent(contentOfApplication, incidentType, postDate, applicantId, suspiciousEmployees));
        }
    }
}
