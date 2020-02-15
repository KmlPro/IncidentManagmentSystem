using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IncidentReport.Application.Files;

namespace IncidentReport.Infrastructure.FileStorage
{
    // kbytner 15.02.2020 -- currently mock implementation
    public class FileStorageService : IFileStorageService
    {
        public Task DeleteFiles(List<Guid> storageIds)
        {
            return Task.CompletedTask;
        }

        public async Task<List<UploadedFile>> UploadFiles(List<FileData> fileData)
        {
            return fileData.Select(x => new UploadedFile(x.FileName, new Guid())).ToList();
        }
    }
}
