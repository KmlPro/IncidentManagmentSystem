using System;
using IncidentReport.Domain.Aggregates.DraftApplications;

namespace IncidentReport.Application.Boundaries.CreateDraftApplications
{
    public class CreateDraftApplicationOutput
    {
        public CreateDraftApplicationOutput(DraftApplication draftApplication)
        {
            if (draftApplication == null)
            {
                throw new ArgumentNullException(nameof(draftApplication));
            }

            this.Id = draftApplication.Id.Value;
        }

        public Guid Id { get; }
    }
}
