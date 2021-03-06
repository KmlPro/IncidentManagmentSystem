using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using IncidentManagementSystem.ApiBehavioursTests.IncidentReport.TestFixtures.EmployeesFixtures;
using IncidentManagementSystem.ApiBehavioursTests.WebAppTestConfiguration;
using IncidentManagementSystem.Web.IncidentReports;
using IncidentReport.Domain.Entities.Employees.ValueObjects;
using NUnit.Framework;

namespace IncidentManagementSystem.ApiBehavioursTests.IncidentReport.UseCases.PostApplications
{
    [Category(IncidentReportCategoryTitle.Title + " PostApplications")]
    public class PostApplicationsTests
    {
        private const string _path = IncidentReportRoutes.IncidentApplication;
        private readonly TestFixture _testFixture;
        private HttpClient _testClient;
        private EmployeeId _suspiciousEmployee;
        private EmployeeId _applicant;

        public PostApplicationsTests()
        {
            this._testFixture = new TestFixture();
        }

        [OneTimeSetUp]
        public void Setup()
        {
            this._testClient = TestClientFactory.GetHttpClient();
            (this._applicant,this._suspiciousEmployee)= EmployeesTestFixture.PrepareApplicantAndRandomEmployeeInDb();
        }

        [Test]
        public async Task ValidRequestContent_Created()
        {
            var requestContent = this._testFixture.CreateRequestContent(this._suspiciousEmployee.Value, null);
            var response = await this._testClient.PostAsync(_path, requestContent);

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            Assert.NotNull(response.Headers.Location);
        }

        [Test]
        public async Task WithDraftApplicationId_Created()
        {
            var draftApplicationId = this._testFixture.CreateDraftApplicationInDb(this._applicant, this._suspiciousEmployee);
            var requestContent = this._testFixture.CreateRequestContent(this._suspiciousEmployee.Value, draftApplicationId);

            var response = await this._testClient.PostAsync(_path, requestContent);

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            Assert.NotNull(response.Headers.Location);
        }
    }
}
