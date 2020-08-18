using IncidentReport.Domain.IncidentVerificationApplications.IncidentApplications;
using IncidentReport.Infrastructure.ForTests;

namespace IncidentManagementSystem.ApiBehavioursTests.TestFixtures.IncidentReports.IncidentApplications
{
    public class IncidentApplicationTestFixture
    {
        public void SaveIncidentApplicationInDb(IncidentApplication incidentApplication)
        {
            TestDatabaseInitializer.SeedDataForTest(dbContext =>
                {
                    dbContext.IncidentApplication.Add(incidentApplication);
                }
            );
        }
    }
}