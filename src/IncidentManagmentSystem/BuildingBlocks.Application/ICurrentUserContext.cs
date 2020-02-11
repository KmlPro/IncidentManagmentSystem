using System;

namespace BuildingBlocks.Application
{
    public interface ICurrentUserContext
    {
        public Guid UserId { get; }
    }
}
