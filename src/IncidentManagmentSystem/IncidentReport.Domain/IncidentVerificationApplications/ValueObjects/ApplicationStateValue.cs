using BuildingBlocks.Domain.Abstract;

namespace IncidentReport.Domain.IncidentVerificationApplications.ValueObjects
{
    public class ApplicationStateValue: ValueObject
    {
        public static ApplicationStateValue Created => new ApplicationStateValue("Created");
        public static ApplicationStateValue Posted => new ApplicationStateValue("Posted");
        public static ApplicationStateValue Finished => new ApplicationStateValue("Finished");
        public static ApplicationStateValue AwaitingForApplicantResponse => new ApplicationStateValue("AwaitingForApplicantResponse");

        public string Value { get; }

        //kbytner 24.06.2020 - think about rulecheck
        public ApplicationStateValue(string value)
        {
            this.Value = value;
        }
    }
}
