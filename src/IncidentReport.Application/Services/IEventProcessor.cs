using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BuildingBlocks.Domain.Abstract;

namespace IncidentReport.Application.Services
{
    public interface IEventProcessor
    {
        Task Process(IEnumerable<DomainEvent> domainEvents, CancellationToken token);
    }
}
