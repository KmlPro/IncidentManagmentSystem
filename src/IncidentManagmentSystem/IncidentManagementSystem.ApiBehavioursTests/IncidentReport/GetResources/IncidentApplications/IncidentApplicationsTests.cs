using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using IncidentManagementSystem.ApiBehavioursTests.IncidentReport.TestFixtures.EmployeesFixtures;
using IncidentManagementSystem.ApiBehavioursTests.TestUtils;
using IncidentManagementSystem.ApiBehavioursTests.WebAppTestConfiguration;
using IncidentManagementSystem.Web.IncidentReports;
using IncidentReport.Domain.Employees.ValueObjects;
using NUnit.Framework;

namespace IncidentManagementSystem.ApiBehavioursTests.IncidentReport.GetResources.IncidentApplications
{
    [Category(IncidentReportCategoryTitle.Title + " GetIncidentApplications")]
    public class IncidentApplicationsTests
    {
        private const string _path = IncidentReportRoutes.IncidentApplication;
        private HttpClient _testClient;
        private TestFixture _testFixture;
        private EmployeeId _applicant;
        private EmployeeId _suspiciousEmployee;

        public IncidentApplicationsTests()
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
        public async Task Get_Return200()
        {
            this._testFixture.CreatePostedIncidentApplicationInDb(this._applicant,this._suspiciousEmployee);
            var response = await this._testClient.GetAsync(_path);

            Assert.True(IsResponseContentNotEmpty.Check(response));
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Test]
        public async Task WithId_Return200()
        {
            var id = this._testFixture.CreatePostedIncidentApplicationInDb(this._applicant,this._suspiciousEmployee);
            var response = await this._testClient.GetAsync($"{_path}/{id}");

            Assert.True(IsResponseContentNotEmpty.Check(response));
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Test]
        public async Task History_Return200()
        {
            var id = this._testFixture.CreatePostedIncidentApplicationInDb(this._applicant,this._suspiciousEmployee);
            var response = await this._testClient.GetAsync($"{_path}/{id}/history");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
