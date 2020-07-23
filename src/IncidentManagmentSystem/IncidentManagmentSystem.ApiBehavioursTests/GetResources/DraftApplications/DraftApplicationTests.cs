using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using IncidentManagmentSystem.ApiBehavioursTests.GetResources.DraftApplications;
using IncidentManagmentSystem.ApiBehavioursTests.IncidentReport;
using NUnit.Framework;

namespace IncidentManagmentSystem.ApiBehavioursTests.GetResources
{
    [Category(IncidentReportCategoryTitle.Title + " GetDraftApplications")]
    public class DraftApplicationTests
    {
        private const string _path = "api/DraftApplication";
        private HttpClient _testClient;
        private TestFixture _testFixture;

        public DraftApplicationTests()
        {
            this._testFixture = new TestFixture();
        }

        [OneTimeSetUp]
        public void Setup()
        {
            this._testClient = TestClientFactory.GetHttpClient();
        }

        [Test]
        public async Task Get_Return200()
        {
            this._testFixture.CreateDraftApplicationInDB();
            var response = await this._testClient.GetAsync(_path);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            // 24.07.2020 - kbytner - Not all entities was returned. Need To investigate
            var responseContent = response.Content.ReadAsStringAsync().Result;

        }
    }
}
