using System;

namespace BuildingBlocks.Domain.Abstract
{
    public abstract class DomainEvent : IDomainEvent
    {
        public DomainEvent()
        {
            this.OccurredOn = SystemClock.Now;
        }

        public DateTime OccurredOn { get; }
    }
}
