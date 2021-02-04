using System;
using IncidentManagementSystem.ApiBehavioursTests.IncidentReport.TestFixtures.IncidentApplications;
using IncidentReport.Domain.Entities.Employees.ValueObjects;

namespace IncidentManagementSystem.ApiBehavioursTests.IncidentReport.GetResources.IncidentApplications
{
    public class TestFixture
    {
        private IncidentApplicationFactory _incidentApplicationFactory;
        private IncidentApplicationTestFixture _incidentApplicationTestFixture;
        public TestFixture()
        {
            this._incidentApplicationFactory = new IncidentApplicationFactory();
            this._incidentApplicationTestFixture = new IncidentApplicationTestFixture();
        }

        public Guid CreatePostedIncidentApplicationInDb(EmployeeId applicant, EmployeeId suspiciousEmployee)
        {
            var draftApplication = this._incidentApplicationFactory.CreatePostedWithAttachments(applicant, suspiciousEmployee);
            this._incidentApplicationTestFixture.SaveIncidentApplicationInDb(draftApplication);
            return draftApplication.Id.Value;
        }
    }
}
