using System;

namespace IncidentReport.PublicDomain
{
    public class AttachmentDto
    {
        public Guid Id { get; }
        public string FileName { get; }
        public Guid StorageId { get; }

        public AttachmentDto(Guid id, string fileName, Guid storageId)
        {
            this.Id = id;
            this.FileName = fileName;
            this.StorageId = storageId;
        }
    }
}
