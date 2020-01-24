using System.Linq;
using BuildingBlocks.Domain.Interfaces;
using IncidentReport.Domain.IncidentVerificationApplications.Rules.IndicateAtLeastOneSuspect.Exceptions;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;

namespace IncidentReport.Domain.IncidentVerificationApplications.Rules.IndicateAtLeastOneSuspect
{
    public class IndicateAtLeastOneSuspectRule : IBusinessRule
    {
        private SuspiciousEmployees SuspiciousEmployees { get; }

        public IndicateAtLeastOneSuspectRule(SuspiciousEmployees suspiciousEmployees)
        {
            this.SuspiciousEmployees = suspiciousEmployees;
        }

        public void CheckIsBroken()
        {
            if (this.SuspiciousEmployees.Employees.Any())
            {
                throw new NoSuspectsWereIndicatedException(this);
            }
        }
    }
}
