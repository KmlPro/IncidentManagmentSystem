using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using NUnit.Framework;

namespace IncidentManagmentSystem.ApiBehavioursTests.IncidentReport.UpdateDraftApplications
{
    //kbytner 15.06.2020 - think about how to add items to dbcontext
    [Category(IncidentReportCategoryTitle.Title)]
    public class UpdateDraftApplicationsTests : BaseTest
    {
        private const string _path = "api/DraftApplication";
        private readonly TestFixture _testFixture;

        public UpdateDraftApplicationsTests()
        {
            this._testFixture = new TestFixture();
        }

        [Test]
        public async Task ValidRequestParameters_NoContent()
        {
            var requestParameters = this._testFixture.CreateMultipartFormDataContent();

            var response = await this.TestClient.PutAsync(_path, requestParameters);

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            Assert.NotNull(response.Headers.Location);
        }

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
