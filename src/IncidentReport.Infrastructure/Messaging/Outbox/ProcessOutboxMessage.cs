using System;
using MediatR;

namespace IncidentReport.Infrastructure.Messaging.Outbox
{
    public class ProcessOutboxMessage : IRequest
    {
        public ProcessOutboxMessage(Guid messageId)
        {
            this.MessageId = messageId;
        }

        public Guid MessageId { get; }
    }
}
