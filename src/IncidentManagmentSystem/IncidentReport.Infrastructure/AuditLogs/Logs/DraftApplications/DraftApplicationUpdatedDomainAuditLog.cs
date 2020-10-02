using IncidentReport.Domain.IncidentVerificationApplications.Events.DraftApplications;

namespace IncidentReport.Infrastructure.AuditLogs.Logs.DraftApplications
{
    internal class DraftApplicationUpdatedDomainAuditLog : AuditLogTemplate<DraftApplicationUpdatedDomainEvent>
    {
        public override string BuildLog(DraftApplicationUpdatedDomainEvent @event)
        {
            return string.Format(LogResources.DraftApplicationUpdated, @event.Id.Value);
        }
    }
}
