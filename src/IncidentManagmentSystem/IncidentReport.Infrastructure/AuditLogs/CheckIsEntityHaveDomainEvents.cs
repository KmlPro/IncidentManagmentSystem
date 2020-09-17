using System.Linq;
using BuildingBlocks.Domain.Abstract;

namespace IncidentReport.Infrastructure.AuditLogs
{
    public static class CheckIsEntityHaveDomainEvents
    {
        public static bool Check(Entity entity)
        {
            return entity != null && entity.DomainEvents.Any();
        }
    }
}
