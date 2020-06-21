namespace IncidentReport.Infrastructure.Persistence.EnumDescriptions
{
    public class EnumDescription
    {
        public long Id { get; }
        public string Type { get; }
        public string Value { get; }
        public string Description { get; }

        public EnumDescription(string type, string value, string description)
        {
            this.Type = type;
            this.Value = value;
            this.Description = description;
        }
    }
}
