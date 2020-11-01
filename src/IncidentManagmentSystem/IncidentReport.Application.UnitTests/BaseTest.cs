using BuildingBlocks.Application;
using BuildingBlocks.Application.UnitTests;
using IncidentReport.Application.Files;
using IncidentReport.Application.UnitTests.Mocks;

namespace IncidentReport.Application.UnitTests
{
    public class BaseTest : ApplicationLayerBaseTest
    {
        public BaseTest()
        {
            this.CurrentUserContext = new MockCurrentUserContextFactory().CreateUserContext();
            this.IFileStorageService = new MockFileStorageServiceFactory().CreateFileStorageService();
        }

        protected ICurrentUserContext CurrentUserContext { get; set; }
        protected IFileStorageService IFileStorageService { get; set; }
    }
}
