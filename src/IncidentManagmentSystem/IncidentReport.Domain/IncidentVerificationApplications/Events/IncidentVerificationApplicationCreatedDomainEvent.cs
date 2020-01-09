using BuildingBlocks.Domain;
using BuildingBlocks.Domain.Abstract;
using IncidentReport.Domain.IncidentVerificationApplications.Enums;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;
using IncidentReport.Domain.Users;

namespace IncidentReport.Domain.IncidentVerificationApplications.Events
{
    public class IncidentVerificationApplicationCreated : DomainEvent
    {
        public ContentOfApplication ContentOfApplication { get; }
        public IncidentType IncidentType { get; }
        public UserId ApplicantId { get; }

        public IncidentVerificationApplicationCreated(ContentOfApplication contentOfApplication, IncidentType incidentType, UserId applicantId)
        {
            this.ContentOfApplication = contentOfApplication;
            this.IncidentType = incidentType;
            this.ApplicantId = applicantId;
        }
    }
}
