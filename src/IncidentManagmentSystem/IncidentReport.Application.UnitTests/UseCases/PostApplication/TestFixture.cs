using IncidentReport.Application.Boundaries.PostApplicationUseCase;
using IncidentReport.Application.UnitTests.Factories;
using IncidentReport.Domain.IncidentVerificationApplications.DraftApplications;

namespace IncidentReport.Application.UnitTests.UseCases.PostApplication
{
    public class TestFixture
    {
        public PostApplicationInput CreateInputWithoutDraft()
        {
            throw new System.NotImplementedException();
        }

        public PostApplicationInput CreateInputWithDraft(DraftApplication draftApplication)
        {
            throw new System.NotImplementedException();
        }

        public DraftApplication PrepareDraftApplication(IDraftApplicationRepository draftApplicationRepository)
        {
            var draftApplication = DraftApplicationFactory.Create();
            draftApplicationRepository.Create(draftApplication);
            return draftApplication;
        }
    }
}
