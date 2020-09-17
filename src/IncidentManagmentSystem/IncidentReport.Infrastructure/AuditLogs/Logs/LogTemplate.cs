using BuildingBlocks.Domain.Abstract;

namespace IncidentReport.Infrastructure.AuditLogs.Logs
{
    public abstract class LogTemplate<TEvent> where TEvent : DomainEvent
    {
        public abstract string LogResource { get; }
        public abstract string BuildLog(TEvent @event);
    }
}
