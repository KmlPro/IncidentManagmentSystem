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

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<List<UploadedFile>> UploadFiles(List<FileData> fileData)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            return fileData.Select(x => new UploadedFile(x.FileName, new Guid())).ToList();
        }
    }
}
