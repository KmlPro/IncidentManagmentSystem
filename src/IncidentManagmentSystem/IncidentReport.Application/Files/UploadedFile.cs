using System;

namespace IncidentReport.Application.Files
{
    public class UploadedFile
    {
        public UploadedFile(string fileName, Guid storageId)
        {
            this.FileName = fileName;
            this.StorageId = storageId;
        }

        public string FileName { get; }
        public Guid StorageId { get; }
    }
}
