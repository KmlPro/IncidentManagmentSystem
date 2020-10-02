using System.Linq;
using IncidentReport.Domain.IncidentVerificationApplications.Events.DraftApplications;

namespace IncidentReport.Infrastructure.AuditLogs.Logs.DraftApplications
{
    internal class DraftApplicationAttachmentsAddedAuditLog : AuditLogTemplate<DraftApplicationAttachmentsAdded>
    {
        public override string BuildLog(DraftApplicationAttachmentsAdded @event)
        {
            var fileNames = @event.AddedAttachments.Select(x => x.FileInfo.FileName).ToList();
            var fileNamesJoined = string.Join(", ",fileNames);
            return string.Format(LogResources.DraftApplicationAttachmentsAdded, fileNamesJoined);
        }
    }
}
