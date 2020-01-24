using System.Collections.Generic;

namespace BuildingBlocks.Domain.Abstract
{
    public abstract class Entity : WithCheckRule
    {
        private List<DomainEvent> _domainEvents;
        public IReadOnlyCollection<DomainEvent> DomainEvents => this._domainEvents?.AsReadOnly();

        protected void AddDomainEvent(DomainEvent domainEvent)
        {
            this._domainEvents ??= new List<DomainEvent>();
            this._domainEvents.Add(domainEvent);
        }

        public void ClearDomainEvents()
        {
            this._domainEvents?.Clear();
        }
    }
}
