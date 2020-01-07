using BuildingBlocks.Domain;
using IncidentReport.Domain.IncidentVerificationApplications.Enums;

namespace IncidentReport.Domain.IncidentVerificationApplications.Events
{
    public class IncidentVerificationApplicationCreated : DomainEvent
    {
        public string Title { get; }
        public string Content { get; }
        public IncidentType IncidentType { get; }

        public IncidentVerificationApplicationCreated(string title, string content, IncidentType incidentType)
        {
            this.Title = title;
            this.Content = content;
            this.IncidentType = incidentType;
        }
    }
}
