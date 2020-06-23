using System;

namespace IncidentReport.PublicDomain
{
    public class AttachmentsDto
    {
        public Guid Id { get; }
        public string FileName { get; }
        public Guid StorageId { get; }

        public AttachmentsDto(Guid id, string fileName, Guid storageId)
        {
            this.Id = id;
            this.FileName = fileName;
            this.StorageId = storageId;
        }
    }
}
