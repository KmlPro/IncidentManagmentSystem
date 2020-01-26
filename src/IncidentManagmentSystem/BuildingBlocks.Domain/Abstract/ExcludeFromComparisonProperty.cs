using System;

namespace BuildingBlocks.Domain.Abstract
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class ExcludeFromComparisonPropertyAttribute : Attribute
    {
    }
}
