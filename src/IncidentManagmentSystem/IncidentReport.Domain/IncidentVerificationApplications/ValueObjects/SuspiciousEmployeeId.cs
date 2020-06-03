using System;
using BuildingBlocks.Domain.Abstract;

namespace IncidentReport.Domain.IncidentVerificationApplications.ValueObjects
{
    public class SuspiciousEmployeeId : TypedIdValue
    {
        public SuspiciousEmployeeId(Guid value) : base(value)
        {
        }
    }
}
