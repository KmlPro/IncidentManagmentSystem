using System;
using BuildingBlocks.Domain.Abstract;

namespace IncidentReport.Domain.IncidentVerificationApplications.ValueObjects
{
    public class PostedApplicationId : TypedIdValueBase
    {
        public PostedApplicationId(Guid value) : base(value)
        {
        }
    }
}
