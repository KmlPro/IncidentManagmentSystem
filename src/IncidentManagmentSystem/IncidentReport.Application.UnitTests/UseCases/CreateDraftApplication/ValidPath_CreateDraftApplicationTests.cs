using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BuildingBlocks.Application.UnitTests;
using IncidentReport.Application.UseCases;
using NUnit.Framework;

namespace IncidentReport.Application.UnitTests.UseCases.CreateDraftApplication
{
    [Category(CategoryTitle.Title + " CreateDraftApplicationUseCase")]
    public class ValidPath_CreateDraftApplicationTests : BaseTest
    {
        private readonly TestFixture _testFixture;

        public ValidPath_CreateDraftApplicationTests()
        {
            this._testFixture = new TestFixture();
        }

        [Test]
        public async Task AllFieldsAreFilled_OnlyWithoutAttachments_DraftCreatedSuccessfully()
        {
            //Arrange
            var useCase = this._testFixture.CreateUseCaseWithRequiredFields();
            var handler = new CreateDraftApplicationUseCase(this.IncidentReportDbContext, this.CurrentUserContext,
                this.IFileStorageService, new CreateDraftApplicationUseCaseOutputPort());

            //Act
            var useCaseOutput =
                (CreateDraftApplicationUseCaseOutputPort)await handler.Handle(useCase, new CancellationToken());

            //Assert
            var isDraftApplicationAddedToContext =
                this.IncidentReportDbContext.DraftApplication.Any(x => x.Id.Value == useCaseOutput.Id);

            Assert.IsTrue(isDraftApplicationAddedToContext);
            Assert.AreEqual(OutputPortInvokedMethod.Standard, useCaseOutput.InvokedOutputMethod);
        }

        [Test]
        public async Task AllFieldsAreFilled_WithAttachments_DraftCreatedSuccessfully()
        {
            //Arrange
            var command = this._testFixture.CreateUseCaseWithRequiredFields(new List<string> { "testFile.pdf" });
            var handler = new CreateDraftApplicationUseCase(this.IncidentReportDbContext, this.CurrentUserContext,
                this.IFileStorageService, new CreateDraftApplicationUseCaseOutputPort());

            //Act
            var useCaseOutput =
                (CreateDraftApplicationUseCaseOutputPort)await handler.Handle(command, new CancellationToken());

            //Assert
            var isDraftApplicationAddedToContext =
                this.IncidentReportDbContext.DraftApplication.Any(x => x.Id.Value == useCaseOutput.Id);

            Assert.IsTrue(isDraftApplicationAddedToContext);
            Assert.AreEqual(OutputPortInvokedMethod.Standard, useCaseOutput.InvokedOutputMethod);
        }
    }
}
