using System;

namespace BuildingBlocks.Domain.Interfaces
{
    public interface IClock
    {
        DateTime Now => DateTime.UtcNow;
    }
}
