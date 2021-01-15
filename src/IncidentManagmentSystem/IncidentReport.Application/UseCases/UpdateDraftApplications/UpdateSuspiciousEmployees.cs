using System.Collections.Generic;
using System.Linq;
using IncidentReport.Application.Boundaries.UpdateDraftApplications;
using IncidentReport.Domain.Employees.ValueObjects;
using IncidentReport.Domain.IncidentVerificationApplications.DraftApplications;

namespace IncidentReport.Application.UseCases.UpdateDraftApplications
{
    public class UpdateSuspiciousEmployees
    {
        //kbytner 15.01.2021 - move this to domain layer
        public void Handle(DraftApplication draftApplication, UpdateDraftApplicationInput input)
        {
            var newSuspiciousEmployees = this.GetNewSuspiciousEmployees(draftApplication, input);
            var removedSuspiciousEmployees = this.GetRemovedSuspiciousEmployees(draftApplication, input);

            if (newSuspiciousEmployees.Any())
            {
                draftApplication.AddSuspiciousEmployees(newSuspiciousEmployees);
            }

            if (removedSuspiciousEmployees.Any())
            {
                draftApplication.DeleteSuspiciousEmployees(removedSuspiciousEmployees);
            }
        }

        private List<EmployeeId> GetRemovedSuspiciousEmployees(DraftApplication draftApplication, UpdateDraftApplicationInput input)
        {
            return draftApplication.SuspiciousEmployees.
                Where(se => !input.SuspiciousEmployees.Contains(se.EmployeeId.Value))
                .Select(x => x.EmployeeId).ToList();
        }

        private List<EmployeeId> GetNewSuspiciousEmployees(DraftApplication draftApplication, UpdateDraftApplicationInput input)
        {
            return input.SuspiciousEmployees.
                Where(se => !draftApplication.SuspiciousEmployees.Select(x => x.EmployeeId.Value).Contains(se))
                .Select(x => new EmployeeId(x)).ToList();
        }
    }
}
