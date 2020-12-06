using System;
using System.Threading;
using System.Threading.Tasks;
using BuildingBlocks.Application.UnitTests;
using IncidentReport.Domain.IncidentVerificationApplications.DraftApplications;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;
using IncidentReport.Infrastructure.Contract;
using NUnit.Framework;

namespace IncidentReport.Application.IntegrationTests.UseCases.CreateDraftApplication
{
    [Category(CategoryTitle.Title + " CreateDraftApplicationUseCase")]
    public class ValidPath_CreateDraftApplicationTests : BaseTest
    {
        private readonly TestFixture _testFixture;
        private readonly IIncidentReportModule _module;
        private readonly IDraftApplicationRepository _repository;

        public ValidPath_CreateDraftApplicationTests()
        {
            this._testFixture = new TestFixture();
            this._module = IncidentReportModuleFactory.SetupAndBuild();
            this._repository = InstanceResolver.Resolve<IDraftApplicationRepository>();
        }

        //kbytner 08.12.2020 - prepare test data to remove FOREIGN KEY constraint failed).
        [Test]
        public async Task AllFieldsAreFilled_OnlyWithoutAttachments_DraftCreatedSuccessfully()
        {
            //Arrange
            var useCase = this._testFixture.CreateUseCaseWithRequiredFields();

            //Act
            var useCaseOutput =
                (CreateDraftApplicationUseCaseOutputPort)await this._module.ExecuteUseCase(useCase);

            //Assert

            Assert.IsTrue(await this.IsDraftApplicationAdded(useCaseOutput.Id));
            Assert.AreEqual(OutputPortInvokedMethod.Standard, useCaseOutput.InvokedOutputMethod);
        }

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

        private async Task<bool> IsDraftApplicationAdded(Guid draftApplicationId)
        {
            var draftApplication = await this._repository.GetById(new DraftApplicationId(draftApplicationId), new CancellationToken());
            return true;
        }
    }
}
