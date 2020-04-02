using IncidentReport.Domain.IncidentVerificationApplications;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;

namespace IncidentReport.Domain.UnitTests.IncidentVerificationApplications.Builders
{
    public class AttachmentBuilder
    {
        private FileInfo _fileInfo;
        private StorageId _storageId;

        public AttachmentBuilder SetFileInfo(FileInfo fileInfo)
        {
            this._fileInfo = fileInfo;
            return this;
        }

        public AttachmentBuilder SetStorageId(StorageId storageId)
        {
            this._storageId = storageId;
            return this;
        }

        public Attachment Build()
        {
            return new Attachment(this._fileInfo, this._storageId);
        }
    }
}
