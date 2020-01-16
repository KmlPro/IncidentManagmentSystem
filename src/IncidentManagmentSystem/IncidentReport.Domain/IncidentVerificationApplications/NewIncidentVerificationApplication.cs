using BuildingBlocks.Domain.Abstract;
using BuildingBlocks.Domain.Interfaces;
using IncidentReport.Domain.IncidentVerificationApplications.Enums;
using IncidentReport.Domain.IncidentVerificationApplications.Events;
using IncidentReport.Domain.IncidentVerificationApplications.Rules.ApplicantCannotBeSuspectRule;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;
using IncidentReport.Domain.Users;

namespace IncidentReport.Domain.IncidentVerificationApplications
{
    public class NewIncidentVerificationApplication : Entity, IAggregateRoot
    {
        public ApplicationIdValue Id { get; }
        public ContentOfApplication ContentOfApplication { get; }
        public IncidentType IncidentType { get; }
        public UserId ApplicantId { get; }
        public SuspiciousEmployees SuspiciousEmployees { get; }
        public UserId CreatorId { get; }

        public static NewIncidentVerificationApplication Create(ContentOfApplication contentOfApplication, IncidentType incidentType, UserId applicantId, SuspiciousEmployees suspiciousEmployees, UserId creatorId)
        {
            return new NewIncidentVerificationApplication(contentOfApplication, incidentType, applicantId, suspiciousEmployees, creatorId);
        }

        public PostedIncidentVerificationApplication SendToVerification()
        {
            return PostedIncidentVerificationApplication.Create(this.ContentOfApplication, this.IncidentType, this.ApplicantId, this.SuspiciousEmployees, this.CreatorId);
        }

        private NewIncidentVerificationApplication(ContentOfApplication contentOfApplication, IncidentType incidentType, UserId applicantId, SuspiciousEmployees suspiciousEmployees, UserId creatorId)
        {
            this.CheckRule(new ApplicantCannotBeSuspectRule(suspiciousEmployees, applicantId));

            this.ContentOfApplication = contentOfApplication;
            this.IncidentType = incidentType;
            this.ApplicantId = applicantId;
            this.SuspiciousEmployees = suspiciousEmployees;
            this.CreatorId = creatorId;

            this.AddDomainEvent(new IncidentVerificationApplicationCreated(contentOfApplication, incidentType, applicantId, suspiciousEmployees, creatorId));
        }
    }
}
