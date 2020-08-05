using System;
using BuildingBlocks.Domain.Abstract;

namespace IncidentReport.Domain.IncidentVerificationApplications.ValueObjects
{
    public class ApplicationId : TypedIdValue
    {
        public ApplicationId(Guid value) : base(value)
        {
        }
    }
}
