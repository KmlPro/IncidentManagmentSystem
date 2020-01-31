using System;
using BuildingBlocks.Domain.Abstract;

namespace IncidentReport.Domain.IncidentVerificationApplications.ValueObjects
{
    public class DraftApplicationId : TypedIdValueBase
    {
        private DraftApplicationId()
        {

        }
        public DraftApplicationId(Guid value) : base(value)
        {
        }
    }
}
