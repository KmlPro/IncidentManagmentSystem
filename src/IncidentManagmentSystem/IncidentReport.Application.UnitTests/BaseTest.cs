using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BuildingBlocks.Infrastructure;
using IncidentReport.Application.Common;
using IncidentReport.Application.Common.File;
using IncidentReport.Application.User;
using IncidentReport.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Moq;
using NUnit.Framework;

namespace IncidentReport.Application.UnitTests
{
    public class BaseTest
    {
        protected IIncidentReportDbContext IncidentReportDbContext { get; set; }
        protected ICurrentUserContext CurrentUserContext { get; set; }

        [SetUp]
        public void UnitTestBaseSetUp()
        {
            this.IncidentReportDbContext = this.CreateDbContext();
            this.CurrentUserContext = this.CreateUserContext();
        }

        private IIncidentReportDbContext CreateDbContext()
        {
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<IncidentReportDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>();

            var context = new IncidentReportDbContext(dbContextOptionsBuilder.Options);

            context.Database.EnsureCreated();
            return context;
        }

        private ICurrentUserContext CreateUserContext()
        {
            var currentUserServiceMock = new Mock<ICurrentUserContext>();
            currentUserServiceMock.Setup(m => m.UserId)
                .Returns(Guid.NewGuid());

            return currentUserServiceMock.Object;
        }

        protected IFileStorageService CreateFileStorageService(int uploadedFilesCount)
        {
            var mockFileData = new List<UploadedFile>();
            for (var i = 0; i < uploadedFilesCount; i++)
            {
                mockFileData.Add(new UploadedFile(Faker.StringFaker.Alpha(10) + ".pdf", Guid.NewGuid()));
            }

            var fileStorageServiceMock = new Mock<IFileStorageService>();
            fileStorageServiceMock.Setup(m => m.UploadFiles(It.IsAny<List<FileData>>())).Returns(Task.FromResult(mockFileData));

            return fileStorageServiceMock.Object;
        }
    }
}
