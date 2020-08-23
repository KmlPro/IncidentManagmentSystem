using IncidentReport.Domain.IncidentVerificationApplications.DraftApplications;
using IncidentReport.Infrastructure.ForTests;

namespace IncidentManagementSystem.ApiBehavioursTests.IncidentReport.TestFixtures.DraftApplicationFixtures
{
    public class DraftApplicationTestFixture
    {
        public void SaveDraftApplicationInDb(DraftApplication draftApplication)
        {
            TestDatabaseInitializer.SeedDataForTest(dbContext =>
                {
                    dbContext.DraftApplication.Add(draftApplication);
                }
            );
        }
    }
}
