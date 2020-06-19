using System;
using IncidentReport.Domain.IncidentVerificationApplications;

namespace IncidentReport.Application.Boundaries.UpdateDraftApplications
{
    //kbytner 20.06.2020 -- think about void use cases
    public class UpdateDraftApplicationOutput
    {
        public UpdateDraftApplicationOutput(DraftApplication draftApplication)
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
