using BuildingBlocks.Domain.Abstract;
using Dawn;

namespace IncidentReport.Domain.IncidentVerificationApplications.ValueObjects
{
    public class Title : ValueObject
    {
        public string Value { get; }

        public Title(string value)
        {
            Guard.Argument(value).NotEmpty();
            this.Value = value;
        }

        private Title()
        {
        }
    }
}
