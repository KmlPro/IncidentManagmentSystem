using System;
using System.Collections.Generic;
using Autofac.Core.Registration;
using Autofac.Features.Indexed;
using BuildingBlocks.Domain.Abstract;
using IncidentReport.Infrastructure.AuditLogs.Logs;
using IncidentReport.Infrastructure.Configuration.JsonConvertContractResolvers;
using Newtonsoft.Json;
using Serilog;

namespace IncidentReport.Infrastructure.AuditLogs
{
    public class AuditLogService
    {
        private readonly IIndex<string, IAuditLogFactory> _logFactories;
        private readonly ILogger _logger;

        public AuditLogService(IIndex<string, IAuditLogFactory> logFactories,ILogger logger)
        {
            this._logFactories = logFactories;
            this._logger = logger;
        }

        public List<AuditLog> CreateFromDomainEvents(Entity entity)
        {
            var auditLogs = new List<AuditLog>();
            foreach (var domainEvent in entity.DomainEvents)
            {
                var eventData = JsonConvert.SerializeObject(domainEvent, new JsonSerializerSettings()
                    { ContractResolver = new IgnorePropertiesResolver(new[] { nameof(domainEvent.Type), nameof(domainEvent.OccurredOn) }) });

                var eventType = domainEvent.GetType().ToString();
                var description = this.GetDescription(domainEvent,eventType);
                auditLogs.Add(new AuditLog(domainEvent.OccurredOn, domainEvent.Type, eventData, domainEvent.EntityId, description));
            }

            return auditLogs;
        }

        //kbytner 27.09.2020 - should think about catch this exception. Maybe its important thing and should throw exception?
        private string GetDescription(DomainEvent domainEvent, string eventType)
        {
            try
            {
                var logFactory = this._logFactories[eventType];

                return logFactory != null ? logFactory.Create(domainEvent) : "";
            }
            catch (ComponentNotRegisteredException ex)
            {
                this._logger.Error(ex, $"Can't find LogFactory for {eventType}");
                return "";
            }
        }
    }
}
