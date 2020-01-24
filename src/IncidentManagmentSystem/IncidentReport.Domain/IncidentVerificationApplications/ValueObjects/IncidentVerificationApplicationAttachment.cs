using BuildingBlocks.Domain.Abstract;

namespace IncidentReport.Domain.IncidentVerificationApplications.ValueObjects
{
    public class IncidentVerificationApplicationAttachment : ValueObject
    {
        public FileData FileData { get; }
        public StorageId StorageId { get; }

        public IncidentVerificationApplicationAttachment(FileData fileData, StorageId storageId)
        {
            this.FileData = fileData;
            this.StorageId = storageId;
        }
    }
}
