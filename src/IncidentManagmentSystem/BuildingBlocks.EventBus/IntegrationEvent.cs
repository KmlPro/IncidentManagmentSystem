using System;
using MediatR;

namespace BuildingBlocks.EventBus
{
    public abstract class IntegrationEvent : INotification
    {
        public Guid Id { get; }

        public DateTime OccurredOn { get; }

        protected IntegrationEvent(Guid id, DateTime occurredOn)
        {
            this.Id = id;
            this.OccurredOn = occurredOn;
        }
    }
}
