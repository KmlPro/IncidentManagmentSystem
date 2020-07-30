using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using IncidentManagementSystem.ApiBehavioursTests.EmployeesFixtures;
using IncidentReport.Domain.Employees.ValueObjects;
using NUnit.Framework;

namespace IncidentManagementSystem.ApiBehavioursTests.IncidentReport.CreateDraftApplications
{
    [Category(IncidentReportCategoryTitle.Title + " CreateDraftApplications")]
    public class CreateDraftApplicationsTests
    {
        private const string _path = "api/draft-application";
        private readonly TestFixture _testFixture;
        private HttpClient _testClient;
        private EmployeeId _suspiciousEmployee;

        public CreateDraftApplicationsTests()
        {
            this._testFixture = new TestFixture();
        }

        [OneTimeSetUp]
        public void Setup()
        {
            this._testClient = TestClientFactory.GetHttpClient();
            (_,this._suspiciousEmployee) = EmployeesTestFixture.PrepareApplicantAndRandomEmployeeInDb();
        }

        [Test]
        public async Task ValidRequestParameters_Created()
        {
            var requestParameters = this._testFixture.CreateMultipartFormDataContent(this._suspiciousEmployee.Value);

            var response = await this._testClient.PostAsync(_path, requestParameters);

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            Assert.NotNull(response.Headers.Location);
        }

        [Test]
        public async Task ValidRequestParameters_WithAttachments_Created()
        {
            var requestParameters = this._testFixture.CreateMultipartFormDataContent(this._suspiciousEmployee.Value);
            this._testFixture.AddAttachments(requestParameters, new List<string> { "test1.txt", "test2.txt" });

            var response = await this._testClient.PostAsync(_path, requestParameters);

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            Assert.NotNull(response.Headers.Location);
        }
    }
}
