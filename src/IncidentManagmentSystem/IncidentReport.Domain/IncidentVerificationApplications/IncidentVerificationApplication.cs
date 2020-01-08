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
        public string Title { get; }
        public string Content { get; }
        public IncidentType IncidentType { get; }
        public UserId ApplicantId { get; }

        private IncidentVerificationApplication()
        {

        }

        public static IncidentVerificationApplication Create(string title, string content, IncidentType incidentType, UserId applicantId)
        {
            return new IncidentVerificationApplication(title, content, incidentType, applicantId);
        }

        public PostedIncidentVerificationApplication SendToVerification()
        {
            return PostedIncidentVerificationApplication.Create(this.Title, this.Content, this.IncidentType, this.ApplicantId);
        }

        private IncidentVerificationApplication(string title, string content, IncidentType incidentType, UserId applicantId)
        {
            this.Title = title;
            this.Content = content;
            this.IncidentType = incidentType;
            this.ApplicantId = applicantId;

            this.AddDomainEvent(new IncidentVerificationApplicationCreated(title, content, incidentType, applicantId));
        }
    }
}
