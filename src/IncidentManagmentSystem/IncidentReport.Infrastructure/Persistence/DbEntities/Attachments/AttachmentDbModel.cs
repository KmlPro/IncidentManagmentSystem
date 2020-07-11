using System;

namespace IncidentReport.Infrastructure.Persistence.DbEntities.Attachments
{
    public class AttachmentDbModel
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public Guid StorageId { get; set; }
    }
}
