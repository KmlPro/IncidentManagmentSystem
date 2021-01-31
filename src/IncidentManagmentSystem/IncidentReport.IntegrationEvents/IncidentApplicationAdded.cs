using System;
using BuildingBlocks.IntegrationEvents;

namespace IncidentReport.IntegrationEvents
{
    public class IncidentApplicationAdded : IntegrationEvent
    {
        public string ApplicationNumber { get; set; }

        public IncidentApplicationAdded(Guid id, DateTime occurredOn, string applicationNumber) : base(id, occurredOn)
        {
            this.ApplicationNumber = applicationNumber;
        }
    }
}
