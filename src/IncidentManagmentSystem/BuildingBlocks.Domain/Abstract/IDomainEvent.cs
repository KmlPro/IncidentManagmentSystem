using System;

namespace BuildingBlocks.Domain.Abstract
{
    public interface IDomainEvent
    {
        DateTime OccurredOn { get; }
        string Type { get; }
        string EntityId { get; }
    }
}
