using System.Collections.Generic;
using System.Linq;
using BuildingBlocks.Domain.Interfaces;
using IncidentReport.Domain.Employees.ValueObjects;
using IncidentReport.Domain.IncidentVerificationApplications.Rules.IndicateAtLeastOneSuspect.Exceptions;

namespace IncidentReport.Domain.IncidentVerificationApplications.Rules.IndicateAtLeastOneSuspect
{
    public class IndicateAtLeastOneSuspectRule : IBusinessRule
    {
        private readonly List<EmployeeId> _suspiciousEmployees;

        public IndicateAtLeastOneSuspectRule(List<EmployeeId> suspiciousEmployees)
        {
            this._suspiciousEmployees = suspiciousEmployees;
        }

        public void CheckIsBroken()
        {
            if (this._suspiciousEmployees.Any())
            {
                throw new NoSuspectsWereIndicatedException(this);
            }
        }
    }
}
