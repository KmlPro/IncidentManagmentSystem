using System;

namespace BuildingBlocks.Domain
{
    public interface IClock
    {
        DateTime Now => DateTime.UtcNow;
    }
}
