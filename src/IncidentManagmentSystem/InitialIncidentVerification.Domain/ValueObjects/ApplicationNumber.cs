using BuildingBlocks.Domain.Abstract;

namespace InitialIncidentVerification.Domain.ValueObjects
{
    public class ApplicationNumber : ValueObject
    {
        public ApplicationNumber(string value)
        {
            this.Value = value;
        }

        public string Value { get; }
    }
}
