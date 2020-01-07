using BuildingBlocks.Domain;
using IncidentReport.Domain.IncidentVerificationApplications.Enums;
using IncidentReport.Domain.IncidentVerificationApplications.Events;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;

namespace IncidentReport.Domain.IncidentVerificationApplications
{
    public class IncidentVerificationApplication : Entity, IAggregateRoot
    {
        public ApplicationIdValue Id { get; }
        public string Title { get; }
        public string Content { get; }
        public IncidentType IncidentType { get; }

        private IncidentVerificationApplication()
        {

        }

        public static IncidentVerificationApplication Create(string title, string content, IncidentType incidentType)
        {
            return new IncidentVerificationApplication(title, content, incidentType);
        }

        public PostedIncidentVerificationApplication SendToVerification()
        {
            return PostedIncidentVerificationApplication.Create(this.Title, this.Content, this.IncidentType);
        }

        private IncidentVerificationApplication(string title, string content, IncidentType incidentType)
        {
            this.Title = title;
            this.Content = content;
            this.IncidentType = incidentType;

            this.AddDomainEvent(new IncidentVerificationApplicationCreated(title, content, incidentType));
        }
    }
}
