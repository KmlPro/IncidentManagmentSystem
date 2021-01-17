using System.Collections.Generic;
using System.Linq;
using BuildingBlocks.Domain.Interfaces;
using IncidentReport.Domain.Employees.ValueObjects;
using IncidentReport.Domain.IncidentVerificationApplications.Rules.IndicateAtLeastOneSuspect.Exceptions;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;

namespace IncidentReport.Domain.IncidentVerificationApplications.Rules.IndicateAtLeastOneSuspect
{
    public class IndicateAtLeastOneSuspectRule : IBusinessRule
    {
        private readonly List<SuspiciousEmployee> _suspiciousEmployees;

        public IndicateAtLeastOneSuspectRule(List<SuspiciousEmployee> suspiciousEmployees)
        {
            this._suspiciousEmployees = suspiciousEmployees;
        }

        public void CheckIsBroken()
        {
            if (!this._suspiciousEmployees.Any())
            {
                throw new NoSuspectsWereIndicatedException(this);
            }
        }
    }
}
