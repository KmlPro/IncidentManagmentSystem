using System;
using BuildingBlocks.Domain.Abstract;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;

namespace IncidentReport.Domain.IncidentVerificationApplications
{
    public class Attachment : Entity
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
