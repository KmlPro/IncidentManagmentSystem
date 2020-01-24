using BuildingBlocks.Domain.Abstract;

namespace IncidentReport.Domain.IncidentVerificationApplications.ValueObjects
{
    public class IncidentVerificationApplicationAttachment : ValueObject
    {
        public FileInfo FileData { get; }
        public StorageId StorageId { get; }

        public IncidentVerificationApplicationAttachment(FileInfo fileData, StorageId storageId)
        {
            this.FileData = fileData;
            this.StorageId = storageId;
        }
    }
}
