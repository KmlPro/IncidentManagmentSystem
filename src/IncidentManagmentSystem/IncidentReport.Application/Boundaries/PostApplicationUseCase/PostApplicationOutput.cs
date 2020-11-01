using System;
using IncidentReport.Domain.IncidentVerificationApplications.IncidentApplications.States;

namespace IncidentReport.Application.Boundaries.PostApplicationUseCase
{
    public class PostApplicationOutput
    {
        public PostApplicationOutput(PostedIncidentApplication postedIncidentApplication)
        {
            if (postedIncidentApplication == null)
            {
                throw new ArgumentNullException(nameof(postedIncidentApplication));
            }

            this.Id = postedIncidentApplication.Id.Value;
        }

        public Guid Id { get; }
    }
}
