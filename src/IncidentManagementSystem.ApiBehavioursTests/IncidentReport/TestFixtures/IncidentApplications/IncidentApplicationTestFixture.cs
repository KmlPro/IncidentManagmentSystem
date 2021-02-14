using IncidentReport.Domain.Aggregates.IncidentApplications;
using IncidentReport.Infrastructure.ForTests;

namespace IncidentManagementSystem.ApiBehavioursTests.IncidentReport.TestFixtures.IncidentApplications
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
