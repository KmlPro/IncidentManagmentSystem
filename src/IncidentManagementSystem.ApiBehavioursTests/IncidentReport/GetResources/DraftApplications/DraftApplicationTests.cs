using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using IncidentManagementSystem.ApiBehavioursTests.IncidentReport.TestFixtures.EmployeesFixtures;
using IncidentManagementSystem.ApiBehavioursTests.TestUtils;
using IncidentManagementSystem.ApiBehavioursTests.WebAppTestConfiguration;
using IncidentManagementSystem.Web.IncidentReports;
using IncidentReport.Domain.Entities.Employees.ValueObjects;
using NUnit.Framework;

namespace IncidentManagementSystem.ApiBehavioursTests.IncidentReport.GetResources.DraftApplications
{
    [Category(IncidentReportCategoryTitle.Title + " GetDraftApplications")]
    public class DraftApplicationTests
    {
        private const string _path = IncidentReportRoutes.DraftApplication;
        private HttpClient _testClient;
        private TestFixture _testFixture;
        private EmployeeId _applicant;
        private EmployeeId _suspiciousEmployee;

        public DraftApplicationTests()
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
            this._testFixture.CreateDraftApplicationInDb(this._applicant,this._suspiciousEmployee);
            var response = await this._testClient.GetAsync(_path);

            Assert.True(IsResponseContentNotEmpty.Check(response));
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Test]
        public async Task TestOdataSelect_Get_Return200()
        {
            var pathWithSelect = _path + "?$select=Title";
            this._testFixture.CreateDraftApplicationInDb(this._applicant, this._suspiciousEmployee);
            var response = await this._testClient.GetAsync(pathWithSelect);

            Assert.True(IsResponseContentNotEmpty.Check(response));
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Test]
        public async Task WithId_Return200()
        {
            var id = this._testFixture.CreateDraftApplicationInDb(this._applicant,this._suspiciousEmployee);
            var response = await this._testClient.GetAsync($"{_path}/{id}");

            Assert.True(IsResponseContentNotEmpty.Check(response));
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
