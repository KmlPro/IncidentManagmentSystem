using System;
using System.Threading;
using System.Threading.Tasks;
using BuildingBlocks.Infrastructure.Events;
using IncidentReport.Infrastructure.Persistence.Repositories;
using MediatR;
using Polly;

namespace IncidentReport.Infrastructure.Messaging.Outbox
{
    public class ProcessOutboxMessageHandler : IRequestHandler<ProcessOutboxMessage>
    {
        private OutboxMessageRepository _outboxRepository;
        private IEventsBus _eventBus;
        private MessageTypeToIntegrationEventMapper _mapper;

        public ProcessOutboxMessageHandler(OutboxMessageRepository outboxRepository, IEventsBus eventBus,
            MessageTypeToIntegrationEventMapper mapper)
        {
            this._outboxRepository = outboxRepository;
            this._eventBus = eventBus;
            this._mapper = mapper;
        }

        public Task<Unit> Handle(ProcessOutboxMessage request, CancellationToken cancellationToken)
        {
            var message = this._outboxRepository.Get(request.MessageId);
            var integrationEvent = this._mapper.Map(message.Type, message.Data);

            var policy = Policy
                .Handle<Exception>()
                .WaitAndRetry(new[]
                {
                    TimeSpan.FromSeconds(1),
                    TimeSpan.FromSeconds(2),
                    TimeSpan.FromSeconds(3)
                });

            var executeResult = policy.ExecuteAndCapture(async () =>
            {
                await this._eventBus.Publish(integrationEvent);
            });

            if (executeResult.Outcome == OutcomeType.Failure)
            {

            }

            return Unit.Task;
        }
    }
}
