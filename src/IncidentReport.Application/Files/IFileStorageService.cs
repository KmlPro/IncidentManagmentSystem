using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IncidentReport.Application.Files
{
    public interface IFileStorageService
    {
        public Task<List<UploadedFile>> UploadFiles(List<FileData> fileData);
        public Task DeleteFiles(List<Guid> storageIds);
    }
}
