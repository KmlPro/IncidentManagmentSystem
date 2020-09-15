using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using IncidentManagementSystem.ApiBehavioursTests.IncidentReport;
using IncidentManagementSystem.ApiBehavioursTests.TestUtils;
using IncidentManagementSystem.Web.IncidentReports;
using NUnit.Framework;

namespace IncidentManagementSystem.ApiBehavioursTests
{
    [Category(IncidentReportCategoryTitle.Title + " GetDraftApplications")]
    public class ApiHealthCheckTest
    {
        private const string _path = IncidentReportRoutes.HealthCheck;
        private HttpClient _testClient;

        [OneTimeSetUp]
        public void Setup()
        {
            this._testClient = TestClientFactory.GetHttpClientProductionStartup();
        }

        [Test]
        public async Task CheckIsAppStartingCorrectly()
        {
            var response = await this._testClient.GetAsync(_path);

            Assert.True(IsResponseContentNotEmpty.Check(response));
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
