using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IncidentReport.Application.Files;
using Moq;

namespace IncidentReport.Application.IntegrationTests.Mocks
{
    internal class MockFileStorageServiceFactory
    {
        private readonly List<UploadedFile> _uploadedFiles;

        public MockFileStorageServiceFactory()
        {
            this._uploadedFiles = new List<UploadedFile>();
        }

        public IFileStorageService CreateFileStorageService()
        {
            var fileStorageServiceMock = new Mock<IFileStorageService>();
            fileStorageServiceMock.Setup(m => m.UploadFiles(It.IsAny<List<FileData>>()))
                .Callback((List<FileData> fd) =>
                    fd.ForEach(x => this._uploadedFiles.Add(new UploadedFile(x.FileName, Guid.NewGuid()))))
                .Returns(Task.FromResult(this._uploadedFiles));

            return fileStorageServiceMock.Object;
        }
    }
}
