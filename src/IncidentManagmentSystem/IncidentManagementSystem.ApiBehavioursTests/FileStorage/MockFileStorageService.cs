using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IncidentReport.Application.Files;

namespace IncidentManagementSystem.ApiBehavioursTests.FileStorage
{
    public class MockFileStorageService : IFileStorageService
    {
        public Task DeleteFiles(List<Guid> storageIds)
        {
            return Task.CompletedTask;
        }

        public async Task<List<UploadedFile>> UploadFiles(List<FileData> fileData)
        {
            return fileData.Select(x => new UploadedFile(x.FileName, Guid.NewGuid())).ToList();
        }
    }
}
