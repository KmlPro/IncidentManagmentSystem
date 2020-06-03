using System.Collections.Generic;
using System.Linq;
using BuildingBlocks.Domain.Interfaces;
using IncidentReport.Domain.Employees.ValueObjects;
using IncidentReport.Domain.IncidentVerificationApplications.Rules.ApplicantCannotBeSuspect.Exceptions;

namespace IncidentReport.Domain.IncidentVerificationApplications.Rules.ApplicantCannotBeSuspect
{
    public class ApplicantCannotBeSuspectRule : IBusinessRule
    {
        private readonly List<EmployeeId> _suspiciousEmployees;
        private readonly EmployeeId _applicantId;

        public ApplicantCannotBeSuspectRule(List<EmployeeId>  suspiciousEmployees, EmployeeId applicantId)
        {
            this._suspiciousEmployees = suspiciousEmployees;
            this._applicantId = applicantId;
        }

        public void CheckIsBroken()
        {
            if (this._suspiciousEmployees != null && this._suspiciousEmployees.Any(x => x == this._applicantId))
            {
                throw new ApplicantCannotBeSuspectRuleException(this);
            }
        }
    }
}
