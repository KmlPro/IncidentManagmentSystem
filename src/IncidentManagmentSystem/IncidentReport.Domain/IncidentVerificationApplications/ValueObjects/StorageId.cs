using System;

namespace IncidentReport.Domain.IncidentVerificationApplications.ValueObjects
{
    public class StorageId
    {
        public Guid Value { get; }

        public StorageId(Guid value)
        {
            this.Value = value;
        }
    }
}
