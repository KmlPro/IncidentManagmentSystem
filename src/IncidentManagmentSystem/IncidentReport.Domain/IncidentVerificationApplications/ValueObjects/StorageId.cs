using System;
using BuildingBlocks.Domain.Abstract;

namespace IncidentReport.Domain.IncidentVerificationApplications.ValueObjects
{
    public class StorageId : TypedIdValueBase
    {
        public StorageId(Guid value) : base(value)
        {
        }
    }
}
