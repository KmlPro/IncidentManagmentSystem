using IncidentReport.Domain.IncidentVerificationApplications.Events.DraftApplications;

namespace IncidentReport.Infrastructure.AuditLogs.Logs.DraftApplications
{
    public class DraftApplicationCreatedAuditLog: AuditLogFactory<DraftApplicationCreatedDomainEvent>
    {
        public override string BuildLog(DraftApplicationCreatedDomainEvent @event)
        {
            return string.Format(LogResources.DraftApplicationCreated, @event.Id.Value);
        }
    }
}
