using BuildingBlocks.Domain;
using BuildingBlocks.Domain.Abstract;

namespace IncidentReport.Domain.IncidentVerificationApplications.ValueObjects
{
    public class ApplicationNumber : ValueObject
    {
        public string Value { get; }

        public ApplicationNumber(string value)
        {
            this.Value = value;
        }
    }
}
