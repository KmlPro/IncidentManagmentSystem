using BuildingBlocks.Domain.Abstract;

namespace IncidentReport.Domain.IncidentVerificationApplications.ValueObjects
{
    public class IncidentType : ValueObject
    {
        public static IncidentType FinancialViolations => new IncidentType("FinancialViolations");
        public static IncidentType AdverseEffectForTheCompany => new IncidentType("AdverseEffectForTheCompany");
        public static IncidentType SuspectedCrime => new IncidentType("SuspectedCrime");

        public string Value { get; }

        //kbytner 24.06.2020 - think about rulecheck
        public IncidentType(string value)
        {
            this.Value = value;
        }
    }
}
