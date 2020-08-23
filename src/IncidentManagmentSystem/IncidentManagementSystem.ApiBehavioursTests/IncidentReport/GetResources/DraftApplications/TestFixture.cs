using IncidentManagementSystem.ApiBehavioursTests.IncidentReport.TestFixtures.DraftApplicationFixtures;
using IncidentReport.Domain.Employees.ValueObjects;

namespace IncidentManagementSystem.ApiBehavioursTests.IncidentReport.GetResources.DraftApplications
{
    public class TestFixture
    {
        private DraftApplicationFactory _draftApplicationFactory;
        private DraftApplicationTestFixture _draftApplicationTestFixture;
        public TestFixture()
        {
            this._draftApplicationFactory = new DraftApplicationFactory();
            this._draftApplicationTestFixture = new DraftApplicationTestFixture();
        }
        public void CreateDraftApplicationInDb(EmployeeId applicant, EmployeeId suspiciousEmployee)
        {
            var draftApplication = this._draftApplicationFactory.CreateWithAttachments(applicant, suspiciousEmployee);
            this._draftApplicationTestFixture.SaveDraftApplicationInDb(draftApplication);
        }
    }
}
