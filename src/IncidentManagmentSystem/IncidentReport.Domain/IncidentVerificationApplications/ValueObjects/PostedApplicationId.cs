using System;

namespace IncidentReport.Domain.IncidentVerificationApplications.ValueObjects
{
    public class PostedApplicationId
    {
        public Guid Value { get; }

        public PostedApplicationId(Guid value)
        {
            this.Value = value;
        }
    }
}
