using System;

namespace IncidentReport.ReadModels.Dtos.Attachments
{
    public class AttachmentDto
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public Guid StorageId { get; set; }
    }
}
