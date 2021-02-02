using System.Threading.Tasks;
using BuildingBlocks.Infrastructure;
using BuildingBlocks.Infrastructure.Events;
using BuildingBlocks.IntegrationEvents;
using Serilog;

//Credits to: https://github.com/kgrzybek/modular-monolith-with-ddd
namespace BuildingBlocks.EventBus
{
    public class InMemoryEventBusClient : IEventsBus
    {
        private readonly ILogger _logger;

        public InMemoryEventBusClient(ILogger logger)
        {
            this._logger = logger;
        }

        public void Dispose()
        {
        }

        public async Task Publish<T>(T @event)
            where T : IntegrationEvent
        {
            this._logger.Information("Publishing {Event}", @event.GetType().FullName);
            await InMemoryEventBus.Instance.Publish(@event);
        }

        public void Subscribe<T>(IIntegrationEventHandler<T> handler)
            where T : IntegrationEvent
        {
            InMemoryEventBus.Instance.Subscribe(handler);
        }
    }
}
