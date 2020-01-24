using System;
using BuildingBlocks.Domain.Abstract;

namespace IncidentReport.Domain.IncidentVerificationApplications.ValueObjects
{
    public class DraftApplicationId : ValueObject
    {
        public Guid Value { get; }

        public DraftApplicationId(Guid value)
        {
            this.Value = value;
        }
    }
}
