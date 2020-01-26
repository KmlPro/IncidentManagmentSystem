using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IncidentReport.Application.Common.File;

namespace IncidentReport.Application.Common
{
    public interface IFileStorageService
    {
        public Task<List<UploadedFile>> UploadFiles(List<FileData> fileData);
        public Task DeleteFiles(List<Guid> storageIds);
    }
}
