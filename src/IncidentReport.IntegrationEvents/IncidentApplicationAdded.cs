using System;
using BuildingBlocks.IntegrationEvents;

namespace IncidentReport.IntegrationEvents
{
    public class IncidentApplicationAdded : IntegrationEvent
    {
        public string ApplicationNumber { get; set; }

        public IncidentApplicationAdded(DateTime occurredOn, string applicationNumber) : base(occurredOn)
        {
            this.ApplicationNumber = applicationNumber;
        }
    }
}
