using BuildingBlocks.Application;
using BuildingBlocks.Application.UnitTests;
using IncidentReport.Application.Files;
using IncidentReport.Application.IntegrationTests.Mocks;

namespace IncidentReport.Application.IntegrationTests
{
    public class BaseTest : ApplicationLayerBaseTest
    {
        public BaseTest()
        {
            this.CurrentUserContext = new TestCurrentUserContext();
            this.IFileStorageService = new MockFileStorageServiceFactory().CreateFileStorageService();
        }

        protected ICurrentUserContext CurrentUserContext { get; set; }
        protected IFileStorageService IFileStorageService { get; set; }
    }
}
