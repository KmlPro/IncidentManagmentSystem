using BuildingBlocks.Domain.Abstract;

namespace IncidentReport.Infrastructure.AuditLogs.Logs
{
    public interface IAuditLogTemplate
    {
        public string EventType { get; }
        public string Create(DomainEvent domainEvent);
    }
}
