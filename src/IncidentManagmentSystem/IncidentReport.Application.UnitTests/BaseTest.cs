using BuildingBlocks.Application;
using BuildingBlocks.Application.UnitTests;
using IncidentReport.Application.Common;
using IncidentReport.Application.Files;
using IncidentReport.Application.UnitTests.Mocks;
using NUnit.Framework;

namespace IncidentReport.Application.UnitTests
{
    public class BaseTest : ApplicationLayerBaseTest
    {
        public BaseTest()
        {
            this.IncidentReportDbContext = new MockDbContextFactory().CreateDbContext();
            this.CurrentUserContext = new MockCurrentUserContextFactory().CreateUserContext();
            this.IFileStorageService = new MockFileStorageServiceFactory().CreateFileStorageService();
        }

        protected IWriteIncidentReportDbContext IncidentReportDbContext { get; set; }
        protected ICurrentUserContext CurrentUserContext { get; set; }
        protected IFileStorageService IFileStorageService { get; set; }
    }
}
