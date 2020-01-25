using System;

namespace IncidentReport.Application.Common.File
{
    public class UploadedFile
    {
        public string FileName { get; }
        public Guid StorageId { get; }

        public UploadedFile(string fileName, Guid storageId)
        {
            this.FileName = fileName;
            this.StorageId = storageId;
        }
    }
}
