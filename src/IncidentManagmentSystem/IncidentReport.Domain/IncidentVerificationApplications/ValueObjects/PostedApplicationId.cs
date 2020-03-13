using System;
using BuildingBlocks.Domain.Abstract;

namespace IncidentReport.Domain.IncidentVerificationApplications.ValueObjects
{
    public class PostedApplicationId : TypedIdValue
    {
        public PostedApplicationId(Guid value) : base(value)
        {
        }
    }
}
