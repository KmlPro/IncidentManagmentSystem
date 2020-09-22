using BuildingBlocks.Domain.Abstract;

namespace IncidentReport.Infrastructure.AuditLogs.Logs
{
    public interface IAuditLogFactory
    {
        public string EventType { get; }
        public string Create(DomainEvent domainEvent);
    }
}
