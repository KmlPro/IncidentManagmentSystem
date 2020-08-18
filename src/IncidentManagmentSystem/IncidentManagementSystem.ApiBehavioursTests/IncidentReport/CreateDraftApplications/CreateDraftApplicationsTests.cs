using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using IncidentManagementSystem.ApiBehavioursTests.TestFixtures.IncidentReports.EmployeesFixtures;
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
        public async Task ValidRequestContent_Created()
        {
            var requestContent = this._testFixture.CreateRequestContent(this._suspiciousEmployee.Value);

            var response = await this._testClient.PostAsync(_path, requestContent);

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            Assert.NotNull(response.Headers.Location);
        }

        [Test]
        public async Task WithAttachments_Created()
        {
            var requestContent = this._testFixture.CreateRequestContent(this._suspiciousEmployee.Value);
            this._testFixture.AddAttachments(requestContent, new List<string> { "test1.txt", "test2.txt" });

            var response = await this._testClient.PostAsync(_path, requestContent);

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            Assert.NotNull(response.Headers.Location);
        }
    }
}
