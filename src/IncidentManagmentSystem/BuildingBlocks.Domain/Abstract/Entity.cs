using System;
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

        protected void CopyDomainEvents(Entity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            this._domainEvents ??= new List<IDomainEvent>();
            this._domainEvents.AddRange(entity.DomainEvents);
        }

        public void ClearDomainEvents()
        {
            this._domainEvents?.Clear();
        }
    }
}
