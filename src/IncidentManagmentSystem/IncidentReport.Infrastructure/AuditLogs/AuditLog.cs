using System;

namespace IncidentReport.Infrastructure.AuditLogs
{
    public class AuditLog
    {
        public string Id { get; set; }
        public DateTime OccurredOn { get; set; }
        public string Type { get; set; }
        public string Data { get; set; }
        public string EntityId { get; set; }
        public string Description { get; set; }

        public AuditLog(DateTime occurredOn, string type, string data, string entityId, string description)
        {
            this.Id = Guid.NewGuid().ToString();
            this.OccurredOn = occurredOn;
            this.Type = type;
            this.Data = data;
            this.EntityId = entityId;
            this.Description = description;
        }
    }
}
