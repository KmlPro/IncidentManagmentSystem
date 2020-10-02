using IncidentReport.Domain.IncidentVerificationApplications.Events.Applications;

namespace IncidentReport.Infrastructure.AuditLogs.Logs.Applications
{
    internal class ApplicationPostedAuditLog : AuditLogTemplate<ApplicationPostedDomainEvent>
    {
        public override string BuildLog(ApplicationPostedDomainEvent @event)
        {
            return string.Format(LogResources.ApplicationPosted, @event.Id.Value);
        }
    }
}
