using System;
using System.Collections.Generic;

namespace BuildingBlocks.Domain.Abstract
{
    public abstract class AggregateRoot : WithCheckRule
    {
        private List<DomainEvent> _domainEvents;
        public IReadOnlyCollection<DomainEvent> DomainEvents => this._domainEvents?.AsReadOnly();

        protected void AddDomainEvent(DomainEvent domainEvent)
        {
            this._domainEvents ??= new List<DomainEvent>();
            this._domainEvents.Add(domainEvent);
        }

        protected void CopyDomainEvents(AggregateRoot aggregateRoot)
        {
            if (aggregateRoot == null)
            {
                throw new ArgumentNullException(nameof(aggregateRoot));
            }
            this._domainEvents ??= new List<DomainEvent>();
            this._domainEvents.AddRange(aggregateRoot.DomainEvents);
        }

        public void ClearDomainEvents()
        {
            this._domainEvents?.Clear();
        }
    }
}
