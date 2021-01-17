using System.Linq;
using BuildingBlocks.Domain.Abstract;

namespace IncidentReport.Infrastructure.AuditLogs
{
    public static class CheckIsEntityHasDomainEvents
    {
        public static bool Check(AggregateRoot aggregateRoot)
        {
            return aggregateRoot != null && aggregateRoot.DomainEvents.Any();
        }
    }
}
