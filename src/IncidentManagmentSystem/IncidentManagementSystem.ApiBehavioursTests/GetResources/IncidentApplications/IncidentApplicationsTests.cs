using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using IncidentManagementSystem.ApiBehavioursTests.IncidentReport;
using IncidentManagementSystem.ApiBehavioursTests.TestFixtures.IncidentReports.EmployeesFixtures;
using IncidentReport.Domain.Employees.ValueObjects;
using NUnit.Framework;

namespace IncidentManagementSystem.ApiBehavioursTests.GetResources.IncidentApplications
{
    [Category(IncidentReportCategoryTitle.Title + " GetIncidentApplications")]
    public class IncidentApplicationsTests
    {
        private const string _path = "api/incident-application";
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

        //kbytner 19.08.2020 - check is something returned and all properties filled. Fix Guid problems with Attachments and Employees
        [Test]
        public async Task Get_Return200()
        {
            this._testFixture.CreatePostedIncidentApplicationInDb(this._applicant,this._suspiciousEmployee);
            var response = await this._testClient.GetAsync(_path);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
