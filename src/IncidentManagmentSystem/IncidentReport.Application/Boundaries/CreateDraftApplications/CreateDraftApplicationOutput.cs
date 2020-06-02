using System;
using System.Linq;
using IncidentReport.Domain.IncidentVerificationApplications;

namespace IncidentReport.Application.Boundaries.CreateDraftApplications
{
    public class CreateDraftApplicationOutput
    {
        public Guid Id { get; }

        public CreateDraftApplicationOutput(DraftApplication draftApplication)
        {
            if (draftApplication == null)
            {
                throw new ArgumentNullException(nameof(draftApplication));
            }

            this.Id = draftApplication.Id.Value;
        }
    }
}
