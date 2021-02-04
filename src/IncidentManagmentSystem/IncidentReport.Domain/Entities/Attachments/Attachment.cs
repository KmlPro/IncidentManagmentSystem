using System;
using BuildingBlocks.Domain.Interfaces;
using IncidentReport.Domain.ValueObjects;

namespace IncidentReport.Domain.Entities.Attachments
{
    public class Attachment : IEntity
    {
        public Attachment(FileInfo fileInfo, StorageId storageId)
        {
            this.Id = new AttachmentId(Guid.NewGuid());
            this.FileInfo = fileInfo;
            this.StorageId = storageId;
        }

        private Attachment()
        {
        }

        public AttachmentId Id { get; }
        public FileInfo FileInfo { get; }
        public StorageId StorageId { get; }
    }
}
