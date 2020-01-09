using BuildingBlocks.Domain;
using BuildingBlocks.Domain.Abstract;
using BuildingBlocks.Domain.Interfaces;
using IncidentReport.Domain.IncidentVerificationApplications.Enums;
using IncidentReport.Domain.IncidentVerificationApplications.Events;
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

        private IncidentVerificationApplication()
        {

        }

        public static IncidentVerificationApplication Create(ContentOfApplication contentOfApplication, IncidentType incidentType, UserId applicantId)
        {
            return new IncidentVerificationApplication(contentOfApplication, incidentType, applicantId);
        }

        public PostedIncidentVerificationApplication SendToVerification()
        {
            return PostedIncidentVerificationApplication.Create(this.ContentOfApplication, this.IncidentType, this.ApplicantId);
        }

        private IncidentVerificationApplication(ContentOfApplication contentOfApplication, IncidentType incidentType, UserId applicantId)
        {
            this.ContentOfApplication = contentOfApplication;
            this.IncidentType = incidentType;
            this.ApplicantId = applicantId;

            this.AddDomainEvent(new IncidentVerificationApplicationCreated(contentOfApplication, incidentType, applicantId));
        }
    }
}
