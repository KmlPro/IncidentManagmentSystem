namespace IncidentReport.Infrastructure.Persistence.EnumDescriptions
{
    public class EnumDescription
    {
        public long Id { get; }
        public string Type { get; }
        public string Value { get; }
        public string Description { get; }

        public EnumDescription(long id, string type, string value, string description)
        {
            this.Id = id;
            this.Type = type;
            this.Value = value;
            this.Description = description;
        }
    }
}
