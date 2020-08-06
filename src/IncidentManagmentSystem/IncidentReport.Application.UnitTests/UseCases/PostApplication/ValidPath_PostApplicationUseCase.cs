using System.Threading;
using System.Threading.Tasks;
using BuildingBlocks.Application.UnitTests;
using IncidentReport.Application.UnitTests.Mocks;
using IncidentReport.Application.UseCases;
using IncidentReport.Domain.IncidentVerificationApplications.DraftApplications;
using IncidentReport.Domain.IncidentVerificationApplications.IncidentApplications;
using NUnit.Framework;

namespace IncidentReport.Application.UnitTests.UseCases.PostApplication
{
    //kbytner 06.08.2020- to do, complete tests with implementation
    public class ValidPath_PostApplicationUseCase : BaseTest
    {
        private TestFixture _testFixture;
        private IDraftApplicationRepository _draftApplicationRepository;
        private IIncidentApplicationRepository _incidentApplicationRepository;

        public ValidPath_PostApplicationUseCase()
        {
            this._testFixture = new TestFixture();
            this._draftApplicationRepository = new MockDraftApplicationRepository();
            this._incidentApplicationRepository = new MockIncidentApplicationRepository();
        }

        [Test]
        public async Task WithoutDraftApplication_PostedSuccessfully()
        {
            var useCase = this._testFixture.CreateInputWithoutDraft();
            var handler = new PostApplicationUseCase(this._incidentApplicationRepository,
                this._draftApplicationRepository, this.CurrentUserContext, this.IFileStorageService,
                new PostApplicationUseCaseOutputPort());

            var useCaseOutput =
                (PostApplicationUseCaseOutputPort)await handler.Handle(useCase, new CancellationToken());

            Assert.AreEqual(OutputPortInvokedMethod.Standard, useCaseOutput.InvokedOutputMethod);
        }

        [Test]
        public async Task WithDraftApplication_PostedSuccessfully()
        {
            var draftApplication =
                this._testFixture.PrepareDraftApplication(this._draftApplicationRepository);

            var useCase = this._testFixture.CreateInputWithDraft(draftApplication);
            var handler = new PostApplicationUseCase(this._incidentApplicationRepository,
                this._draftApplicationRepository, this.CurrentUserContext, this.IFileStorageService,
                new PostApplicationUseCaseOutputPort());

            var useCaseOutput =
                (PostApplicationUseCaseOutputPort)await handler.Handle(useCase, new CancellationToken());

            Assert.AreEqual(OutputPortInvokedMethod.Standard, useCaseOutput.InvokedOutputMethod);
        }
    }
}
