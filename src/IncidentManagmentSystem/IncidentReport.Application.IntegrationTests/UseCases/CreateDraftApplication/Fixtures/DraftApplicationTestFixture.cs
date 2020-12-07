using IncidentReport.Domain.IncidentVerificationApplications.DraftApplications;
using IncidentReport.Infrastructure.ForTests;

namespace IncidentReport.Application.IntegrationTests.UseCases.CreateDraftApplication.Fixtures
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
