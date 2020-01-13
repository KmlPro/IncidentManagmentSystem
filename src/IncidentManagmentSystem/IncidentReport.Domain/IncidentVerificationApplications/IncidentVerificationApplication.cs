using System.Collections.Generic;
using BuildingBlocks.Domain.Abstract;
using BuildingBlocks.Domain.Interfaces;
using IncidentReport.Domain.IncidentVerificationApplications.Enums;
using IncidentReport.Domain.IncidentVerificationApplications.Events;
using IncidentReport.Domain.IncidentVerificationApplications.Rules.ApplicantCannotBeSuspectRule;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;
using IncidentReport.Domain.Users;

namespace IncidentReport.Domain.IncidentVerificationApplications
{
    public class IncidentVerificationApplication : Entity, IAggregateRoot
    {
        public ApplicationIdValue Id { get; }
        public ContentOfApplication ContentOfApplication { get; }
        public IncidentType IncidentType { get; }
        public UserId ApplicantId { get; }
        public List<UserId> SuspiciousEmployees { get; }

        private IncidentVerificationApplication()
        {

        }

        public static IncidentVerificationApplication Create(ContentOfApplication contentOfApplication, IncidentType incidentType, UserId applicantId, List<UserId> suspiciousEmployees)
        {
            return new IncidentVerificationApplication(contentOfApplication, incidentType, applicantId, suspiciousEmployees);
        }

        public PostedIncidentVerificationApplication SendToVerification()
        {
            return PostedIncidentVerificationApplication.Create(this.ContentOfApplication, this.IncidentType, this.ApplicantId, this.SuspiciousEmployees);
        }

        private IncidentVerificationApplication(ContentOfApplication contentOfApplication, IncidentType incidentType, UserId applicantId, List<UserId> suspiciousEmployees)
        {
            this.CheckRule(new ApplicantCannotBeSuspectRule(suspiciousEmployees, applicantId));

            this.ContentOfApplication = contentOfApplication;
            this.IncidentType = incidentType;
            this.ApplicantId = applicantId;
            this.SuspiciousEmployees = suspiciousEmployees;

            this.AddDomainEvent(new IncidentVerificationApplicationCreated(contentOfApplication, incidentType, applicantId, suspiciousEmployees));
        }
    }
}
