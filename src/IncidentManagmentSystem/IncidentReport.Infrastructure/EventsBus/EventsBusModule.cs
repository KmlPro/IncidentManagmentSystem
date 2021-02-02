using Autofac;
using BuildingBlocks.EventBus;
using BuildingBlocks.Infrastructure.Events;

namespace IncidentReport.Infrastructure.EventsBus
{
    internal class EventsBusModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<InMemoryEventBusClient>()
                .As<IEventsBus>()
                .SingleInstance();
        }
    }
}
