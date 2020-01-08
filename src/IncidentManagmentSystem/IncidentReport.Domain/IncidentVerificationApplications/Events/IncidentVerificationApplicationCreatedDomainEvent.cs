using BuildingBlocks.Domain;
using BuildingBlocks.Domain.Abstract;
using IncidentReport.Domain.IncidentVerificationApplications.Enums;
using IncidentReport.Domain.Users;

namespace IncidentReport.Domain.IncidentVerificationApplications.Events
{
    public class IncidentVerificationApplicationCreated : DomainEvent
    {
        public string Title { get; }
        public string Content { get; }
        public IncidentType IncidentType { get; }
        public UserId ApplicantId { get; }

        public IncidentVerificationApplicationCreated(string title, string content, IncidentType incidentType, UserId applicantId)
        {
            this.Title = title;
            this.Content = content;
            this.IncidentType = incidentType;
            this.ApplicantId = applicantId;
        }
    }
}
