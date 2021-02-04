using System;
using BuildingBlocks.Domain.Abstract;

namespace IncidentReport.Domain.ValueObjects
{
    public class StorageId : TypedIdValue
    {
        public StorageId(Guid value) : base(value)
        {
        }
    }
}
