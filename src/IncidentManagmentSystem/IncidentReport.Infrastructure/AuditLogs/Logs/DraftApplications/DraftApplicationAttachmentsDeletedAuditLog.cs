using System.Linq;
using IncidentReport.Domain.IncidentVerificationApplications.Events.DraftApplications;

namespace IncidentReport.Infrastructure.AuditLogs.Logs.DraftApplications
{
    internal class DraftApplicationAttachmentsDeletedAuditLog : AuditLogTemplate<DraftApplicationAttachmentsDeleted>
    {
        public override string BuildLog(DraftApplicationAttachmentsDeleted @event)
        {
            var fileNames = @event.DeletedAttachments.Select(x => x.FileInfo.FileName).ToList();
            var fileNamesJoined = string.Join(", ", fileNames);
            return string.Format(LogResources.DraftApplicationAttachmentsDeleted, fileNamesJoined);
        }
    }
}
