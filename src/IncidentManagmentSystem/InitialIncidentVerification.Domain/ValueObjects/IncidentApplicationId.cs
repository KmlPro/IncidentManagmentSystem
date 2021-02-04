using System;
using BuildingBlocks.Domain.Abstract;

namespace InitialIncidentVerification.Domain.ValueObjects
{
    public class IncidentApplicationId : TypedIdValue
    {
        public IncidentApplicationId(Guid value) : base(value)
        {
        }

        public static IncidentApplicationId Create()
        {
            return new IncidentApplicationId(Guid.NewGuid());
        }
    }
}
