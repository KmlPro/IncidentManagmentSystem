using System.Linq;
using BuildingBlocks.Domain.Interfaces;
using IncidentReport.Domain.Employees.ValueObjects;
using IncidentReport.Domain.IncidentVerificationApplications.Rules.ApplicantCannotBeSuspect.Exceptions;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;

namespace IncidentReport.Domain.IncidentVerificationApplications.Rules.ApplicantCannotBeSuspect
{
    public class ApplicantCannotBeSuspectRule : IBusinessRule
    {
        public SuspiciousEmployees SuspiciousEmployees { get; }
        private EmployeeId ApplicantId { get; }

        public ApplicantCannotBeSuspectRule(SuspiciousEmployees suspiciousEmployees, EmployeeId applicantId)
        {
            this.SuspiciousEmployees = suspiciousEmployees;
            this.ApplicantId = applicantId;
        }

        public void CheckIsBroken()
        {
            if (this.SuspiciousEmployees != null && this.SuspiciousEmployees.Employees.Any(x => x == this.ApplicantId))
            {
                throw new ApplicantCannotBeSuspectRuleException(this);
            }
        }
    }
}
