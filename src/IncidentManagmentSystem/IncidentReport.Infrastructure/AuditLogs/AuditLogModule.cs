using System.Linq;
using System.Runtime.Serialization;
using Autofac;
using IncidentReport.Infrastructure.AuditLogs.Logs;

namespace IncidentReport.Infrastructure.AuditLogs
{
    internal class AuditLogModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var logTemplates = this.ThisAssembly.GetTypes()
                .Where(t => t.IsAssignableTo<IAuditLogFactory>())
                .Where(t => !t.IsAbstract && !t.IsInterface)
                .ToList();

            foreach (var logType in logTemplates)
            {
                var logInstance = (IAuditLogFactory)FormatterServices.GetUninitializedObject(logType);
                var eventType = logInstance.EventType;

                builder.RegisterType(logType)
                    .Keyed<IAuditLogFactory>(eventType);
            }

            builder.RegisterType<AuditLogService>();
        }
    }
}
