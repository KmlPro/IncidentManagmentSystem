using BuildingBlocks.Infrastructure;

namespace BuildingBlocks.EventBus
{
    public class HandlerSubscription
    {
        public HandlerSubscription(IIntegrationEventHandler handler, string eventName)
        {
            this.Handler = handler;
            this.EventName = eventName;
        }

        public IIntegrationEventHandler Handler { get; }

        public string EventName { get; }
    }
}
