using IncidentReport.Domain.IncidentVerificationApplications.Events.DraftApplications;

namespace IncidentReport.Infrastructure.AuditLogs.Logs.DraftApplications
{
    internal class DraftApplicationCreatedAuditLog: AuditLogTemplate<DraftApplicationCreatedDomainEvent>
    {
        public override string BuildLog(DraftApplicationCreatedDomainEvent @event)
        {
            return string.Format(LogResources.DraftApplicationCreated, @event.Id.Value);
        }
    }
}
