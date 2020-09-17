using System.Collections.Generic;
using BuildingBlocks.Domain.Abstract;
using IncidentReport.Infrastructure.Configuration.JsonConvertContractResolvers;
using Newtonsoft.Json;

namespace IncidentReport.Infrastructure.AuditLogs
{
    public class AuditLogFactory
    {
        public List<AuditLog> CreateFromDomainEvents(Entity entity)
        {
            var auditLogs = new List<AuditLog>();
            foreach (var domainEvent in entity.DomainEvents)
            {
                var eventData = JsonConvert.SerializeObject(domainEvent, new JsonSerializerSettings()
                    { ContractResolver = new IgnorePropertiesResolver(new[] { nameof(domainEvent.Type), nameof(domainEvent.OccurredOn) }) });

                auditLogs.Add(new AuditLog(domainEvent.OccurredOn, domainEvent.Type, eventData, domainEvent.EntityId, "TO DO DESCRIPTION"));
            }

            return auditLogs;
        }
    }
}
