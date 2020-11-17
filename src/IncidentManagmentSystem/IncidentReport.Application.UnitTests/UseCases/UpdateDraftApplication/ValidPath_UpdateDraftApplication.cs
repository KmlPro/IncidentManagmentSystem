using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BuildingBlocks.Application.UnitTests;
using IncidentReport.Application.Files;
using IncidentReport.Application.UnitTests.Factories;
using IncidentReport.Application.UnitTests.Mocks;
using IncidentReport.Application.UseCases.UpdateDraftApplications;
using IncidentReport.Domain.IncidentVerificationApplications;
using NUnit.Framework;

namespace IncidentReport.Application.UnitTests.UseCases.UpdateDraftApplication
{
    [Category(CategoryTitle.Title + " UpdateDraftApplicationUseCase")]
    public class ValidPath_UpdateDraftApplication : BaseTest
    {
        private TestFixture _testFixture;
        private MockDraftApplicationRepository _draftApplicationRepository;

        public ValidPath_UpdateDraftApplication()
        {
        }

        [SetUp]
        public void Init()
        {
            this._draftApplicationRepository = new MockDraftApplicationRepository();
            this._testFixture = new TestFixture(this._draftApplicationRepository);
        }

        // [Test]
        // public async Task SuspiciousEmployeeNotChanged_DraftUpdatedSuccessfully()
        // {
        //     //Arrange
        //     var initialSuspiciousEmployees = new List<Guid> { Guid.NewGuid() };
        //     var suspiciousEmployees = initialSuspiciousEmployees;
        //
        //     var useCase = await this._testFixture.PrepareUseCaseWithTestData(suspiciousEmployees, initialSuspiciousEmployees);
        //     var handler = new UpdateDraftApplicationUseCase(this._draftApplicationRepository,
        //         this.IFileStorageService, new UpdateDraftApplicationUseCaseOutputPort());
        //
        //     //Act
        //     var useCaseOutput =
        //         (UpdateDraftApplicationUseCaseOutputPort)await handler.Handle(useCase, new CancellationToken());
        //
        //     //Assert
        //     var draftApplicationFromContext = await this._testFixture.GetDraftFromContext(useCase.DraftApplicationId);
        //
        //     Assert.AreEqual(OutputPortInvokedMethod.Standard, useCaseOutput.InvokedOutputMethod);
        //     Assert.AreEqual(1, draftApplicationFromContext.SuspiciousEmployees.Count);
        // }
        //
        // [Test]
        // public async Task TwoNewSuspiciousEmployeeAdded_OneRemoved_DraftUpdatedSuccessfully()
        // {
        //     //Arrange
        //     var initialSuspiciousEmployees = new List<Guid> { Guid.NewGuid() };
        //     var newSuspiciousEmployees = new List<Guid> { Guid.NewGuid(), Guid.NewGuid() };
        //
        //     var useCase =
        //        await this._testFixture.PrepareUseCaseWithTestData(newSuspiciousEmployees, initialSuspiciousEmployees);
        //     var handler = new UpdateDraftApplicationUseCase(this._draftApplicationRepository,
        //         this.IFileStorageService, new UpdateDraftApplicationUseCaseOutputPort());
        //
        //     //Act
        //     var useCaseOutput =
        //         (UpdateDraftApplicationUseCaseOutputPort)await handler.Handle(useCase, new CancellationToken());
        //
        //     //Assert
        //     var draftApplicationFromContext = await this._testFixture.GetDraftFromContext(useCase.DraftApplicationId);
        //
        //     Assert.AreEqual(OutputPortInvokedMethod.Standard, useCaseOutput.InvokedOutputMethod);
        //     Assert.AreEqual(2, draftApplicationFromContext.SuspiciousEmployees.Count);
        // }
        //
        // [Test]
        // public async Task OneInitialAttachment_TwoAdded_ThreeAttachmentsInDraft()
        // {
        //     //Arrange
        //     var initialAttachment = new List<Attachment>{AttachmentFactory.Create()};
        //     var addedAttachment = new List<FileData> {FileDataFactory.Create(), FileDataFactory.Create()};
        //
        //     var useCase =
        //         await this._testFixture.PrepareUseCaseWithTestData(addedAttachment, null, initialAttachment);
        //     var handler = new UpdateDraftApplicationUseCase(this._draftApplicationRepository,
        //         this.IFileStorageService, new UpdateDraftApplicationUseCaseOutputPort());
        //
        //     //Act
        //     var useCaseOutput =
        //         (UpdateDraftApplicationUseCaseOutputPort)await handler.Handle(useCase, new CancellationToken());
        //
        //     //Assert
        //     var draftApplicationFromContext = await this._testFixture.GetDraftFromContext(useCase.DraftApplicationId);
        //
        //     Assert.AreEqual(OutputPortInvokedMethod.Standard, useCaseOutput.InvokedOutputMethod);
        //     Assert.AreEqual(3, draftApplicationFromContext.Attachments.Count);
        // }
    }
}
