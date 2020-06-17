using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;

namespace IncidentManagmentSystem.ApiBehavioursTests.IncidentReport.UpdateDraftApplications
{
    [Category(IncidentReportCategoryTitle.Title)]
    public class UpdateDraftApplicationsTests
    {
        private const string _path = "api/DraftApplication";
        private readonly TestFixture _testFixture;
        protected HttpClient TestClient { get; private set; }

        public UpdateDraftApplicationsTests()
        {
            this._testFixture = new TestFixture();
        }

        [OneTimeSetUp]
        public void Setup()
        {
            this.TestClient = this._testFixture.GetHttpClient();
        }

        // kbytner 18.06.2020 - data is in dbContext, time to repair test
        [Test]
        public async Task ValidRequestParameters_NoContent()
        {
            var requestParameters = this._testFixture.CreateMultipartFormDataContent();
            var response = await this.TestClient.PutAsync(_path, requestParameters);

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            Assert.NotNull(response.Headers.Location);
        }

        // kbytner 18.06.2020 - data is in dbContext, time to repair test
        [Test]
        public async Task ValidRequestParameters_WithAttachemtns_NoContent()
        {
            var requestParameters = this._testFixture.CreateMultipartFormDataContent();
            this._testFixture.AddAttachments(requestParameters, new List<string> { "test1.txt", "test2.txt" });

            var response = await this.TestClient.PutAsync(_path, requestParameters);

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            Assert.NotNull(response.Headers.Location);
        }
    }
}
