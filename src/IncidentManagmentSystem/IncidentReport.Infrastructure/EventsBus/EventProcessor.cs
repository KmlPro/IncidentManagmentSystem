using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BuildingBlocks.Domain.Abstract;
using IncidentReport.Application.Services;
using IncidentReport.Infrastructure.Persistence.NoDomainEntities;
using IncidentReport.Infrastructure.Persistence.Repositories;
using Newtonsoft.Json;

namespace IncidentReport.Infrastructure.EventsBus
{
    public class EventProcessor : IEventProcessor
    {
        private readonly EventMapper _eventMapper;
        private readonly OutboxMessageRepository _repository;

        public EventProcessor(EventMapper eventMapper, OutboxMessageRepository repository)
        {
            this._eventMapper = eventMapper;
            this._repository = repository;
        }

        public async Task Process(IEnumerable<DomainEvent> domainEvents, CancellationToken token)
        {
            var integrationEvents = this._eventMapper.MapAll(domainEvents);

            foreach (var integrationEvent in integrationEvents)
            {
                var type = integrationEvent.GetType().ToString();
                var data = JsonConvert.SerializeObject(integrationEvent);

                var outboxMessage = new OutboxMessage(integrationEvent.EventId, integrationEvent.OccurredOn, type, data);

                await this._repository.Create(outboxMessage, token);
            }
        }
    }
}
