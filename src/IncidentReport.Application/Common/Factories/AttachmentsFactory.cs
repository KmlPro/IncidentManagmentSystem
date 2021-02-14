using System.Collections.Generic;
using System.Linq;
using IncidentReport.Application.Files;
using IncidentReport.Domain.Entities.Attachments;
using IncidentReport.Domain.ValueObjects;

namespace IncidentReport.Application.Factories
{
    public class AttachmentsFactory
    {
        public List<Attachment> CreateAttachments(List<UploadedFile> files)
        {
            return files.Select(x => new Attachment(new FileInfo(x.FileName), new StorageId(x.StorageId)))
                .ToList();
        }
    }
}
