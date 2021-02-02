using System;
using System.Threading.Tasks;
using BuildingBlocks.IntegrationEvents;

namespace BuildingBlocks.Infrastructure.Events
{
    public interface IEventsBus : IDisposable
    {
        Task Publish<T>(T @event)
            where T : IntegrationEvent;

        void Subscribe<T>(IIntegrationEventHandler<T> handler)
            where T : IntegrationEvent;
    }
}
