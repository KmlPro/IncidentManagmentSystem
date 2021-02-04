using System.Collections.Generic;
using System.Linq;
using BuildingBlocks.Domain.Abstract;
using BuildingBlocks.IntegrationEvents;
using IncidentReport.Domain.Aggregates.IncidentApplications.Events;
using IncidentReport.IntegrationEvents;

namespace IncidentReport.Infrastructure.EventsBus
{
    public class EventMapper
    {
        public IEnumerable<IntegrationEvent> MapAll(IEnumerable<DomainEvent> events)
        {
            return events.Select(this.Map);
        }

        private IntegrationEvent Map(DomainEvent @event)
        {
            switch (@event)
            {
                case IncidentApplicationCreated e:
                    return new IncidentApplicationAdded(e.OccurredOn, e.IncidentApplication.ApplicationNumber.Value);
                default:
                    return null;
            }
        }
    }
}
