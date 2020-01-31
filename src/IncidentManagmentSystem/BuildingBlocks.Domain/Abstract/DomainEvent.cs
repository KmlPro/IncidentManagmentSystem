using System;

namespace BuildingBlocks.Domain.Abstract
{
    public abstract class DomainEvent : IDomainEvent
    {
        public DateTime OccurredOn { get; }

        public DomainEvent()
        {
            this.OccurredOn = SystemClock.Now;
        }
    }
}
