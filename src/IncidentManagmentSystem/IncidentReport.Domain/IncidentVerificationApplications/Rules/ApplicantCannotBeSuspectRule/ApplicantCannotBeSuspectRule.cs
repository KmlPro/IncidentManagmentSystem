using BuildingBlocks.Domain.Interfaces;
using IncidentReport.Domain.IncidentVerificationApplications.Rules.ApplicantCannotBeSuspectRule.Exceptions;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;
using IncidentReport.Domain.Users;

namespace IncidentReport.Domain.IncidentVerificationApplications.Rules.ApplicantCannotBeSuspectRule
{
    internal class ApplicantCannotBeSuspectRule : IBusinessRule
    {
        public SuspiciousEmployees SuspiciousEmployees { get; }
        private UserId ApplicantId { get; }

        public ApplicantCannotBeSuspectRule(SuspiciousEmployees suspiciousEmployees, UserId applicantId)
        {
            this.SuspiciousEmployees = suspiciousEmployees;
            this.ApplicantId = applicantId;
        }

        public void CheckIsBroken()
        {
            if (this.SuspiciousEmployees.Employees.Contains(this.ApplicantId))
            {
                throw new ApplicantCannotBeSuspectRuleException(this);
            }
        }
    }
}
