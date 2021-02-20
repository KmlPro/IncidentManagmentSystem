using System;
using BuildingBlocks.IntegrationEvents;
using Newtonsoft.Json;

namespace IncidentReport.Infrastructure.Messaging
{
    public class MessageTypeToIntegrationEventMapper
    {
        public IntegrationEvent Map(string messageType, string data)
        {
            var type =  Type.GetType(messageType);
            var @event = JsonConvert.DeserializeObject(data, type);

            return @event as IntegrationEvent;
        }
    }
}
