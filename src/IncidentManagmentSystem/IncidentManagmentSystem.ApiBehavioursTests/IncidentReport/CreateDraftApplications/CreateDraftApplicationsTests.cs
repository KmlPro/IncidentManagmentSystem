using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;

namespace IncidentManagmentSystem.ApiBehavioursTests.IncidentReport.CreateDraftApplications
{
    [Category(IncidentReportCategoryTitle.Title)]
    public class CreateDraftApplicationsTests
    {
        private const string _path = "api/DraftApplication";
        private readonly TestFixture _testFixture;
        protected HttpClient TestClient { get; private set; }

        public CreateDraftApplicationsTests()
        {
            this._testFixture = new TestFixture();
        }

        [OneTimeSetUp]
        public void Setup()
        {
            this.TestClient = TestClientFactory.GetHttpClient();
        }

        [Test]
        public async Task ValidRequestParameters_Created()
        {
            var requestParameters = this._testFixture.CreateMultipartFormDataContent();

            var response = await this.TestClient.PostAsync(_path, requestParameters);

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            Assert.NotNull(response.Headers.Location);
        }

        [Test]
        public async Task ValidRequestParameters_WithAttachemtns_Created()
        {
            var requestParameters = this._testFixture.CreateMultipartFormDataContent();
            this._testFixture.AddAttachments(requestParameters, new List<string> { "test1.txt", "test2.txt" });

            var response = await this.TestClient.PostAsync(_path, requestParameters);

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            Assert.NotNull(response.Headers.Location);
        }
    }
}
