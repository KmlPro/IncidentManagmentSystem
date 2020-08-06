using System;
using BuildingBlocks.Domain.Abstract;

namespace IncidentReport.Domain.IncidentVerificationApplications.ValueObjects
{
    public class IncidentApplicationId : TypedIdValue
    {
        public IncidentApplicationId(Guid value) : base(value)
        {
        }
    }
}
