using BuildingBlocks.Application.Commands;
using IncidentReport.Domain.IncidentVerificationApplications.Enums;

namespace IncidentReport.Application.CreateIncidentVerificationApplications
{
    public class CreateIncidentVerificationApplicationCommand : CommandBase
    {
        public string Title { get; }
        public string Content { get; }
        public IncidentType IncidentType { get; }
        public long ApplicantId { get; }
    }
}
