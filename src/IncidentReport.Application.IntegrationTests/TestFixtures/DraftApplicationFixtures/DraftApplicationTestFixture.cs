using IncidentReport.Domain.Aggregates.DraftApplications;
using IncidentReport.Infrastructure.ForTests;

namespace IncidentReport.Application.IntegrationTests.TestFixtures.DraftApplicationFixtures
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
