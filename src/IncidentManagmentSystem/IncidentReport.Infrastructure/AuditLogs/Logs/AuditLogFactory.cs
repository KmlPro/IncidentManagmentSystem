using System;
using BuildingBlocks.Domain.Abstract;

namespace IncidentReport.Infrastructure.AuditLogs.Logs
{
    public abstract class AuditLogFactory<TEvent>: IAuditLogFactory where TEvent : DomainEvent
    {
        public string EventType => nameof(TEvent);

        public abstract string BuildLog(TEvent @event);

        public string Create(DomainEvent domainEvent)
        {
            if (domainEvent == null)
            {
                throw new ArgumentNullException(nameof(domainEvent));
            }

            return this.BuildLog(domainEvent as TEvent);
        }
    }
}
