using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BuildingBlocks.Application.UnitTests;
using IncidentReport.Application.UnitTests.Mocks;
using IncidentReport.Application.UseCases;
using IncidentReport.Application.UseCases.CreateDraftApplications;
using NUnit.Framework;

namespace IncidentReport.Application.UnitTests.UseCases.CreateDraftApplication
{
    [Category(CategoryTitle.Title + " CreateDraftApplicationUseCase")]
    public class ValidPath_CreateDraftApplicationTests : BaseTest
    {
        private readonly TestFixture _testFixture;
        private MockDraftApplicationRepository _draftApplicationRepository;

        public ValidPath_CreateDraftApplicationTests()
        {
            this._testFixture = new TestFixture();
        }

        [SetUp]
        public void Init()
        {
            this._draftApplicationRepository = new MockDraftApplicationRepository();
        }

        // [Test]
        // public async Task AllFieldsAreFilled_OnlyWithoutAttachments_DraftCreatedSuccessfully()
        // {
        //     //Arrange
        //     var useCase = this._testFixture.CreateUseCaseWithRequiredFields();
        //     var handler = new CreateDraftApplicationUseCase(this.CurrentUserContext,
        //         this.IFileStorageService, this._draftApplicationRepository,
        //         new CreateDraftApplicationUseCaseOutputPort());
        //
        //     //Act
        //     var useCaseOutput =
        //         (CreateDraftApplicationUseCaseOutputPort)await handler.Handle(useCase, new CancellationToken());
        //
        //     //Assert
        //
        //     Assert.IsTrue(this.IsDraftApplicationAdded(useCaseOutput.Id));
        //     Assert.AreEqual(OutputPortInvokedMethod.Standard, useCaseOutput.InvokedOutputMethod);
        // }
        //
        // [Test]
        // public async Task AllFieldsAreFilled_WithAttachments_DraftCreatedSuccessfully()
        // {
        //     //Arrange
        //     var command = this._testFixture.CreateUseCaseWithRequiredFields(new List<string> {"testFile.pdf"});
        //     var handler = new CreateDraftApplicationUseCase(this.CurrentUserContext,
        //         this.IFileStorageService, this._draftApplicationRepository,
        //         new CreateDraftApplicationUseCaseOutputPort());
        //
        //     //Act
        //     var useCaseOutput =
        //         (CreateDraftApplicationUseCaseOutputPort)await handler.Handle(command, new CancellationToken());
        //
        //     //Assert
        //     Assert.IsTrue(this.IsDraftApplicationAdded(useCaseOutput.Id));
        //     Assert.AreEqual(OutputPortInvokedMethod.Standard, useCaseOutput.InvokedOutputMethod);
        // }

        private bool IsDraftApplicationAdded(Guid draftApplicationId)
        {
            return this._draftApplicationRepository.DraftApplications.Any(x => x.Id.Value == draftApplicationId);
        }
    }
}
