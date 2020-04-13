using System;
using System.Linq;
using IncidentReport.Domain.IncidentVerificationApplications;

namespace IncidentReport.Application.Boundaries.UpdateDraftApplications
{
    public class UpdateDraftApplicationOutput
    {
        public DraftApplicationResource DraftApplication { get; }

        public UpdateDraftApplicationOutput(DraftApplication draftApplication)
        {
            if (draftApplication == null)
            {
                throw new ArgumentNullException(nameof(draftApplication));
            }

            this.DraftApplication = new DraftApplicationResource(draftApplication.Id,
                draftApplication.ContentOfApplication.Title,
                draftApplication.ContentOfApplication.Description,
                draftApplication.IncidentType,
                draftApplication.SuspiciousEmployees,
                draftApplication.ApplicantId,
                draftApplication.Attachments.ToList());
        }
    }
}
