using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;

namespace IncidentManagmentSystem.ApiBehavioursTests.IncidentReport.UpdateDraftApplications
{
    [Category(IncidentReportCategoryTitle.Title + " UpdateDraftApplications")]
    public class UpdateDraftApplicationsTests
    {
        private const string _path = "api/DraftApplication";
        private readonly TestFixture _testFixture;
        private HttpClient _testClient;

        public UpdateDraftApplicationsTests()
        {
            this._testFixture = new TestFixture();
        }

        [OneTimeSetUp]
        public void Setup()
        {
            this._testClient = TestClientFactory.GetHttpClient();
        }

        [Test]
        public async Task ValidRequestParameters_NoContent()
        {
            var draftApplication = this._testFixture.CreateDraftApplicationInDB();
            var requestParameters = this._testFixture.CreateMultipartFormDataContent(draftApplication.Id.Value);

            var response = await this._testClient.PutAsync(_path, requestParameters);

            Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);
        }

        [Test]
        public async Task ValidRequestParameters_TwoAttachemntsAdded_NoContent()
        {
            var draftApplication = this._testFixture.CreateDraftApplicationInDB();
            var requestParameters = this._testFixture.CreateMultipartFormDataContent(draftApplication.Id.Value);
            this._testFixture.AddAttachments(requestParameters, new List<string> { "test1.txt", "test2.txt" });

            var response = await this._testClient.PutAsync(_path, requestParameters);

            Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);
        }
    }
}
