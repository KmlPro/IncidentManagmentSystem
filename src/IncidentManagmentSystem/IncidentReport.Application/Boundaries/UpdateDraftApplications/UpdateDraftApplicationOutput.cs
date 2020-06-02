using System;
using IncidentReport.Domain.IncidentVerificationApplications;

namespace IncidentReport.Application.Boundaries.UpdateDraftApplications
{
    public class UpdateDraftApplicationOutput
    {
        public UpdateDraftApplicationOutput(DraftApplication draftApplication)
        {
            if (draftApplication == null)
            {
                throw new ArgumentNullException(nameof(draftApplication));
            }
        }
    }
}
