using System.Collections.Generic;
using Autofac.Features.Indexed;
using BuildingBlocks.Domain.Abstract;
using IncidentReport.Infrastructure.AuditLogs.Logs;
using IncidentReport.Infrastructure.Configuration.JsonConvertContractResolvers;
using Newtonsoft.Json;

namespace IncidentReport.Infrastructure.AuditLogs
{
    public class AuditLogService
    {
        private readonly IIndex<string, IAuditLogFactory> _logFactories;

        public AuditLogService(IIndex<string, IAuditLogFactory> logFactories)
        {
            this._logFactories = logFactories;
        }

        public List<AuditLog> CreateFromDomainEvents(Entity entity)
        {
            var auditLogs = new List<AuditLog>();
            foreach (var domainEvent in entity.DomainEvents)
            {
                var eventData = JsonConvert.SerializeObject(domainEvent, new JsonSerializerSettings()
                    { ContractResolver = new IgnorePropertiesResolver(new[] { nameof(domainEvent.Type), nameof(domainEvent.OccurredOn) }) });

                var description = this.GetDescription(domainEvent);
                auditLogs.Add(new AuditLog(domainEvent.OccurredOn, domainEvent.Type, eventData, domainEvent.EntityId, description));
            }

            return auditLogs;
        }

        private string GetDescription(DomainEvent domainEvent)
        {
           var logFactory = this._logFactories[nameof(domainEvent)];

           return logFactory != null ? logFactory.Create(domainEvent) : "";
        }
    }
}
