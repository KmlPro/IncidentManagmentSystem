using System;
using BuildingBlocks.Domain.Abstract;

namespace BuildingBlocks.Application.Commands
{
    public class EntityCreatedCommandResult<TEntity> : ICommandResult where TEntity : Entity
    {
        public Guid Id { get; }

        public TEntity Entity { get; }

        public EntityCreatedCommandResult(Guid typedId, TEntity entity)
        {
            this.Id = typedId;
            this.Entity = entity;
        }
    }
}
