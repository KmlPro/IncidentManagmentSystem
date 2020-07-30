using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using IncidentManagementSystem.ApiBehavioursTests.EmployeesFixtures;
using IncidentManagementSystem.ApiBehavioursTests.IncidentReport;
using IncidentReport.Domain.Employees.ValueObjects;
using NUnit.Framework;

namespace IncidentManagementSystem.ApiBehavioursTests.GetResources.DraftApplications
{
    [Category(IncidentReportCategoryTitle.Title + " GetDraftApplications")]
    public class DraftApplicationTests
    {
        private const string _path = "api/draft-application";
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
            this._testFixture.CreateDraftApplicationInDB(this._applicant,this._suspiciousEmployee);
            var response = await this._testClient.GetAsync(_path);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
