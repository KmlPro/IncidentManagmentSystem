using System.Collections.Generic;
using BuildingBlocks.Domain.Interfaces;
using IncidentReport.Domain.IncidentVerificationApplications.Rules.SuspiciousEmployeesCannotHaveApplicantId.Exceptions;
using IncidentReport.Domain.Users;

namespace IncidentReport.Domain.IncidentVerificationApplications.Rules.ApplicantCannotBeSuspectRule
{
    internal class ApplicantCannotBeSuspectRule : IBusinessRule
    {
        private List<UserId> SuspiciousEmployeesIds { get; }
        private UserId ApplicantId { get; }

        public ApplicantCannotBeSuspectRule(List<UserId> suspiciousEmployeesIds, UserId applicantId)
        {
            this.SuspiciousEmployeesIds = suspiciousEmployeesIds;
            this.ApplicantId = applicantId;
        }

        public void CheckIsBroken()
        {
            if (this.SuspiciousEmployeesIds.Contains(this.ApplicantId))
            {
                throw new ApplicantCannotBeSuspectRuleException(this);
            }
        }
    }
}
