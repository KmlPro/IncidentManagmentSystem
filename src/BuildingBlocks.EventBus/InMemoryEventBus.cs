using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuildingBlocks.Infrastructure;
using BuildingBlocks.IntegrationEvents;

//Credits to: https://github.com/kgrzybek/modular-monolith-with-ddd
namespace BuildingBlocks.EventBus
{
    public sealed class InMemoryEventBus
    {
        static InMemoryEventBus()
        {
        }

        private InMemoryEventBus()
        {
            this._handlers = new List<HandlerSubscription>();
        }

        public static InMemoryEventBus Instance { get; } = new InMemoryEventBus();

        private readonly List<HandlerSubscription> _handlers;

        public void Subscribe<T>(IIntegrationEventHandler<T> handler)
            where T : IntegrationEvent
        {
            this._handlers.Add(new HandlerSubscription(handler, typeof(T).FullName));
        }

        public async Task Publish<T>(T @event)
            where T : IntegrationEvent
        {
            var eventType = @event.GetType();

            var integrationEventHandlers = this._handlers.Where(x => x.EventName == eventType.FullName).ToList();

            foreach (var integrationEventHandler in integrationEventHandlers)
            {
                if (integrationEventHandler.Handler is IIntegrationEventHandler<T> handler)
                {
                    await handler.Handle(@event);
                }
            }
        }
    }
}
