using System;
using System.Collections.Generic;
using IncidentReport.Application.Common.File;

namespace IncidentReport.Application.Common
{
    public interface IFileStorageService
    {
        public List<UploadedFile> UploadFiles(List<FileData> fileData);
        public void DeleteFiles(List<Guid> storageIds);
    }
}
