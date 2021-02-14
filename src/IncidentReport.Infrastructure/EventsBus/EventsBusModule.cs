using Autofac;
using BuildingBlocks.EventBus;
using BuildingBlocks.Infrastructure.Events;
using IncidentReport.Application.Services;

namespace IncidentReport.Infrastructure.EventsBus
{
    internal class EventsBusModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EventMapper>().AsSelf()
                .SingleInstance();

            builder.RegisterType<EventProcessor>()
                .As<IEventProcessor>()
                .SingleInstance();

            builder.RegisterType<InMemoryEventBusClient>()
                .As<IEventsBus>()
                .SingleInstance();
        }
    }
}
