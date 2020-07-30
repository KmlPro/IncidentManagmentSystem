using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using IncidentManagementSystem.ApiBehavioursTests.EmployeesFixtures;
using IncidentReport.Domain.Employees.ValueObjects;
using NUnit.Framework;

namespace IncidentManagementSystem.ApiBehavioursTests.IncidentReport.UpdateDraftApplications
{
    [Category(IncidentReportCategoryTitle.Title + " UpdateDraftApplications")]
    public class UpdateDraftApplicationsTests
    {
        private const string _path = "api/draft-application";
        private readonly TestFixture _testFixture;
        private HttpClient _testClient;
        private EmployeeId _applicant;
        private EmployeeId _suspiciousEmployee;

        public UpdateDraftApplicationsTests()
        {
            this._testFixture = new TestFixture();
        }

        [OneTimeSetUp]
        public void Setup()
        {
            this._testClient = TestClientFactory.GetHttpClient();
            (this._applicant,this._suspiciousEmployee) = EmployeesTestFixture.PrepareApplicantAndRandomEmployeeInDb();
        }

        [Test]
        public async Task ValidRequestParameters_NoContent()
        {
            var draftApplication = this._testFixture.CreateDraftApplicationInDb(this._applicant,this._suspiciousEmployee);
            var requestParameters = this._testFixture.CreateMultipartFormDataContent(draftApplication.Id.Value);

            var response = await this._testClient.PutAsync(_path, requestParameters);

            Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);
        }

        [Test]
        public async Task WithAttachemnts_NoContent()
        {
            var draftApplication = this._testFixture.CreateDraftApplicationInDb(this._applicant,this._suspiciousEmployee);
            var requestParameters = this._testFixture.CreateMultipartFormDataContent(draftApplication.Id.Value);
            this._testFixture.AddAttachments(requestParameters, new List<string> { "test1.txt", "test2.txt" });

            var response = await this._testClient.PutAsync(_path, requestParameters);

            Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);
        }

        [Test]
        public async Task ExistsOneAttachment_AddTwoAttachments_DeleteOne_NoContent()
        {
            var draftApplication = this._testFixture.CreateDraftApplicationInDb(this._applicant,this._suspiciousEmployee,true);
            var requestParameters = this._testFixture.CreateMultipartFormDataContent(draftApplication.Id.Value);
            this._testFixture.AddDeletedAttachments(requestParameters, draftApplication.Attachments.Select(x => x.Id.Value).ToList());
            this._testFixture.AddAttachments(requestParameters, new List<string> { "test1.txt", "test2.txt" });

            var response = await this._testClient.PutAsync(_path, requestParameters);

            Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);
        }
    }
}
