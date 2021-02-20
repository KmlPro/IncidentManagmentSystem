using Autofac;
using BuildingBlocks.Infrastructure.Events;
using BuildingBlocks.IntegrationEvents;
using IncidentReport.Infrastructure.DIContainer;
using Serilog;

namespace IncidentReport.Infrastructure.EventsBus
{
    //Credits to: https://github.com/kgrzybek/modular-monolith-with-ddd
    internal static class EventsBusStartup
    {
        internal static void Initialize(
            ILogger logger)
        {
            SubscribeToIntegrationEvents(logger);
        }

        private static void SubscribeToIntegrationEvents(ILogger logger)
        {
            var eventBus = CompositionRoot.BeginLifetimeScope().Resolve<IEventsBus>();
        }

        private static void SubscribeToIntegrationEvent<T>(IEventsBus eventBus, ILogger logger)
            where T : IntegrationEvent
        {
            logger.Information("Subscribe to {@IntegrationEvent}", typeof(T).FullName);
            eventBus.Subscribe(
                new IntegrationEventGenericHandler<T>());
        }
    }
}
