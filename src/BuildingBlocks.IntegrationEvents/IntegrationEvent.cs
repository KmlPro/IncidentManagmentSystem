using System;
using MediatR;

namespace BuildingBlocks.IntegrationEvents
{
    public abstract class IntegrationEvent : INotification
    {
        public Guid EventId { get; }

        public DateTime OccurredOn { get; }

        protected IntegrationEvent(DateTime occurredOn)
        {
            this.EventId = Guid.NewGuid();
            this.OccurredOn = occurredOn;
        }
    }
}
