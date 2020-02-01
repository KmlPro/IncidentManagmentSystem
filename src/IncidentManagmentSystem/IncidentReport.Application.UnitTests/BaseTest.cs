using System;
using IncidentReport.Application.Common;
using IncidentReport.Application.User;
using Moq;
using NUnit.Framework;

namespace IncidentReport.Application.UnitTests
{
    public class BaseTest
    {
        protected IIncidentReportDbContext IncidentReportDbContext { get; set; }
        protected ICurrentUserContext CurrentUserContext { get; set; }
        protected IFileStorageService IFileStorageService { get; set; }

        [SetUp]
        public void UnitTestBaseSetUp()
        {
            this.IncidentReportDbContext = new MockDbContextFactory().CreateDbContext();
            this.CurrentUserContext = this.CreateUserContext();
            this.IFileStorageService = new MockFileStorageServiceFactory().CreateFileStorageService();
        }

        private ICurrentUserContext CreateUserContext()
        {
            var currentUserServiceMock = new Mock<ICurrentUserContext>();
            currentUserServiceMock.Setup(m => m.UserId)
                .Returns(Guid.NewGuid());

            return currentUserServiceMock.Object;
        }
    }
}
