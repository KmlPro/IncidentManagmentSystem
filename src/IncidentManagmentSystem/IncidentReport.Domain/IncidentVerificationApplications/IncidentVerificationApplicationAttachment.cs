using System;
using BuildingBlocks.Domain.Abstract;

namespace IncidentReport.Domain.IncidentVerificationApplications.ValueObjects
{
    public class IncidentVerificationApplicationAttachment : Entity
    {
        public AttachmentId Id { get; }
        public FileInfo FileInfo { get; }
        public StorageId StorageId { get; }

        public IncidentVerificationApplicationAttachment(FileInfo fileInfo, StorageId storageId)
        {
            this.Id = new AttachmentId(Guid.NewGuid());
            this.FileInfo = fileInfo;
            this.StorageId = storageId;
        }

        private IncidentVerificationApplicationAttachment()
        {

        }
    }
}
