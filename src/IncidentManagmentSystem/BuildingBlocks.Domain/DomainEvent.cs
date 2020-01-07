using System;

namespace BuildingBlocks.Domain
{
    public class DomainEvent : IDomainEvent
    {
        public DateTime OccurredOn { get; }

        public DomainEvent()
        {
            this.OccurredOn = SystemClock.Now;
        }
    }
}
