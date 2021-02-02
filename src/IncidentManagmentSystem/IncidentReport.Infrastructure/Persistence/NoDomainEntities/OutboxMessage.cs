using System;

namespace IncidentReport.Infrastructure.Persistence.NoDomainEntities
{
    public class OutboxMessage
    {
        public Guid Id { get; }

        public DateTime OccurredOn { get; }

        public string Type { get; }

        public string Data { get; }

        public DateTime? ProcessedDate { get; private set; }

        public OutboxMessage(Guid id, DateTime occurredOn, string type, string data)
        {
            this.Id = id;
            this.OccurredOn = occurredOn;
            this.Type = type;
            this.Data = data;
        }

        private OutboxMessage()
        {
        }

        public void SetProcessedDate(DateTime processedDate)
        {
            this.ProcessedDate = processedDate;
        }
    }
}
