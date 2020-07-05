using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using IncidentManagmentSystem.ApiBehavioursTests.IncidentReport;
using NUnit.Framework;

namespace IncidentManagmentSystem.ApiBehavioursTests.GetResources
{
    [Category(IncidentReportCategoryTitle.Title + " GetDraftApplications")]
    public class DraftApplicationTests
    {
        private const string _path = "api/DraftApplication";
        private HttpClient _testClient;

        public DraftApplicationTests()
        {
        }

        [OneTimeSetUp]
        public void Setup()
        {
            this._testClient = TestClientFactory.GetHttpClient();
        }

        [Test]
        public async Task Get_Return200()
        {
            var response = await this._testClient.GetAsync(_path);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
