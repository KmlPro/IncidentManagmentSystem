using System.Threading.Tasks;
using BuildingBlocks.Infrastructure;
using BuildingBlocks.IntegrationEvents;
using IncidentReport.Infrastructure.Configuration.DIContainer;

namespace IncidentReport.Infrastructure.EventsBus
{
    internal class IntegrationEventGenericHandler<T> : IIntegrationEventHandler<T>
        where T : IntegrationEvent
    {
        public async Task Handle(T @event)
        {
            using var scope = CompositionRoot.BeginLifetimeScope();
            //kbytner 02.02.2021 - Save Event To Process Later
        }
    }
}
