using System.Linq;
using IncidentReport.Domain.IncidentVerificationApplications.Events.DraftApplications;

namespace IncidentReport.Infrastructure.AuditLogs.Logs.DraftApplications
{
    public class DraftApplicationAttachmentsAddedLog : LogTemplate<DraftApplicationAttachmentsAdded>
    {
        public override string LogResource { get; } = LogResources.DraftApplicationAttachmentsAdded;

        public override string BuildLog(DraftApplicationAttachmentsAdded @event)
        {
            var fileNames = @event.AddedAttachments.Select(x => x.FileInfo.FileName).ToList();
            var fileNamesJoined = string.Join(", ",fileNames);
            return string.Format(LogResource, fileNamesJoined);
        }
    }
}
