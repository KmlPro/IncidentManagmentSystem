using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BuildingBlocks.Application.UnitTests;
using IncidentReport.Application.UnitTests.Mocks;
using IncidentReport.Application.UseCases;
using IncidentReport.Application.UseCases.PostApplications;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;
using NUnit.Framework;

namespace IncidentReport.Application.UnitTests.UseCases.PostApplication
{
    [Category(CategoryTitle.Title + " PostApplicationUseCase")]
    public class ValidPath_PostApplicationUseCase : BaseTest
    {
        private TestFixture _testFixture;
        private MockDraftApplicationRepository _draftApplicationRepository;
        private MockIncidentApplicationRepository _incidentApplicationRepository;

        public ValidPath_PostApplicationUseCase()
        {
            this._testFixture = new TestFixture();
        }

        [SetUp]
        public void Init()
        {
            this._draftApplicationRepository = new MockDraftApplicationRepository();
            this._incidentApplicationRepository = new MockIncidentApplicationRepository();
        }

        // [Test]
        // public async Task WithoutDraftApplication_PostedSuccessfully()
        // {
        //     var useCase = this._testFixture.CreateInput(null);
        //     var handler = new PostApplicationUseCase(this._incidentApplicationRepository,
        //         this._draftApplicationRepository, this.CurrentUserContext, this.IFileStorageService,
        //         new PostApplicationUseCaseOutputPort());
        //
        //     var useCaseOutput =
        //         (PostApplicationUseCaseOutputPort)await handler.Handle(useCase, new CancellationToken());
        //
        //     Assert.AreEqual(OutputPortInvokedMethod.Standard, useCaseOutput.InvokedOutputMethod);
        //     Assert.AreEqual(1, this.CountPostedApplications());
        // }
        //
        // [Test]
        // public async Task WithDraftApplication_PostedSuccessfully()
        // {
        //     var draftApplication =
        //         this._testFixture.PrepareDraftApplication(this._draftApplicationRepository);
        //
        //     var useCase = this._testFixture.CreateInput(draftApplication.Id);
        //     var handler = new PostApplicationUseCase(this._incidentApplicationRepository,
        //         this._draftApplicationRepository, this.CurrentUserContext, this.IFileStorageService,
        //         new PostApplicationUseCaseOutputPort());
        //
        //     var useCaseOutput =
        //         (PostApplicationUseCaseOutputPort)await handler.Handle(useCase, new CancellationToken());
        //
        //     Assert.AreEqual(OutputPortInvokedMethod.Standard, useCaseOutput.InvokedOutputMethod);
        //     Assert.AreEqual(1, this.CountPostedApplications());
        //     Assert.AreEqual(0, this._draftApplicationRepository.DraftApplications.Count);
        // }

        private int CountPostedApplications()
        {
            return this._incidentApplicationRepository.IncidentApplications.Count(x =>
                x.ApplicationState == ApplicationStateValue.Posted);
        }
    }
}
