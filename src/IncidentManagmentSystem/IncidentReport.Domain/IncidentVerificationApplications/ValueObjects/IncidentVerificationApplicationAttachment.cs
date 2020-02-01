using BuildingBlocks.Domain.Abstract;

namespace IncidentReport.Domain.IncidentVerificationApplications.ValueObjects
{
    public class IncidentVerificationApplicationAttachment : ValueObject
    {
        public FileInfo FileInfo { get; }
        public StorageId StorageId { get; }

        public IncidentVerificationApplicationAttachment(FileInfo fileInfo, StorageId storageId)
        {
            this.FileInfo = fileInfo;
            this.StorageId = storageId;
        }

        private IncidentVerificationApplicationAttachment()
        {

        }
    }
}
