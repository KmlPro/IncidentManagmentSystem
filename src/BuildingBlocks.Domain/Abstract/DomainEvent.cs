using System;

namespace BuildingBlocks.Domain.Abstract
{
    public abstract class DomainEvent : IDomainEvent
    {
        public DomainEvent(string entityId)
        {
            this.OccurredOn = SystemClock.Now;
            this.EntityId = entityId;
        }

        public DateTime OccurredOn { get; }
        public string Type => this.GetType().Name;
        public string EntityId { get; }
    }
}
