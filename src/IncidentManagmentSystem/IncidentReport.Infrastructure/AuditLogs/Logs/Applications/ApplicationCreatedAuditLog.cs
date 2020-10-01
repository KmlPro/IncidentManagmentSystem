using IncidentReport.Domain.IncidentVerificationApplications.Events.Applications;

namespace IncidentReport.Infrastructure.AuditLogs.Logs.Applications
{
    internal class ApplicationCreatedAuditLog : AuditLogFactory<ApplicationCreatedDomainEvent>
    {
        public override string BuildLog(ApplicationCreatedDomainEvent @event)
        {
            return string.Format(LogResources.ApplicationCreated, @event.Id.Value);
        }
    }
}
