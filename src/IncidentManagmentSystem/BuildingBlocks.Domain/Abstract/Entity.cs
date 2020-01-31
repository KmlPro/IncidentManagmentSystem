using System.Collections.Generic;

namespace BuildingBlocks.Domain.Abstract
{
    public abstract class Entity : WithCheckRule
    {
        private List<IDomainEvent> _domainEvents;
        public IReadOnlyCollection<IDomainEvent> DomainEvents => this._domainEvents?.AsReadOnly();

        protected void AddDomainEvent(IDomainEvent domainEvent)
        {
            this._domainEvents ??= new List<IDomainEvent>();
            this._domainEvents.Add(domainEvent);
        }

        public void ClearDomainEvents()
        {
            this._domainEvents?.Clear();
        }
    }
}
