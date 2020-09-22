using System.Linq;
using BuildingBlocks.Domain.Abstract;

namespace IncidentReport.Infrastructure.AuditLogs
{
    public static class CheckIsEntityHasDomainEvents
    {
        public static bool Check(Entity entity)
        {
            return entity != null && entity.DomainEvents.Any();
        }
    }
}
