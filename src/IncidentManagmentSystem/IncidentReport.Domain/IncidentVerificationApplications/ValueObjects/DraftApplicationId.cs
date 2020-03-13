using System;
using BuildingBlocks.Domain.Abstract;

namespace IncidentReport.Domain.IncidentVerificationApplications.ValueObjects
{
    public class DraftApplicationId : TypedIdValue
    {
        private DraftApplicationId()
        {

        }
        public DraftApplicationId(Guid value) : base(value)
        {
        }
    }
}
