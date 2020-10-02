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

        public AuditLog()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
