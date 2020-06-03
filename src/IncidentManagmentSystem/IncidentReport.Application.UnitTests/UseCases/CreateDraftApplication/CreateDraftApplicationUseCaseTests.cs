using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BuildingBlocks.Application.UnitTests;
using BuildingBlocks.Domain.UnitTests;
using IncidentReport.Application.Boundaries.CreateDraftApplications;
using IncidentReport.Application.Files;
using IncidentReport.Application.Files.Exceptions;
using IncidentReport.Application.UseCases;
using IncidentReport.Domain.IncidentVerificationApplications.Enums;
using NUnit.Framework;

namespace IncidentReport.Application.UnitTests.UseCases.CreateDraftApplication
{
    public class CreateDraftApplicationUseCaseTests : BaseTest
    {
        [Test]
        public async Task AllFieldsAreFilled_OnlyWithoutAttachments_DraftCreatedSuccessfully()
        {
            //Arrange
            var command = this.CreateUseCaseWithRequiredFields();
            var outputPort = new CreateDraftApplicationUseCaseOutputPort();
            var handler = new CreateDraftApplicationUseCase(this.IncidentReportDbContext, this.CurrentUserContext,
                this.IFileStorageService, outputPort);

            //Act
            var useCaseOutput =
                (CreateDraftApplicationUseCaseOutputPort)await handler.Handle(command, new CancellationToken());

            //Assert
            var isDraftApplicationAddedToContext =
                this.IncidentReportDbContext.DraftApplications.Any(x => x.Id.Value == useCaseOutput.Id);

            Assert.IsTrue(isDraftApplicationAddedToContext);
            Assert.AreEqual(OutputPortInvokedMethod.Standard, useCaseOutput.InvokedOutputMethod);
        }

        [Test]
        public async Task AllFieldsAreFilled_WithAttachments_DraftCreatedSuccessfully()
        {
            //Arrange
            var command = this.CreateUseCaseWithRequiredFields(new List<string> {"testFile.pdf"});
            var outputPort = new CreateDraftApplicationUseCaseOutputPort();
            var handler = new CreateDraftApplicationUseCase(this.IncidentReportDbContext, this.CurrentUserContext,
                this.IFileStorageService, outputPort);

            //Act
            var useCaseOutput =
                (CreateDraftApplicationUseCaseOutputPort)await handler.Handle(command, new CancellationToken());

            //Assert
            var isDraftApplicationAddedToContext =
                this.IncidentReportDbContext.DraftApplications.Any(x => x.Id.Value == useCaseOutput.Id);

            Assert.IsTrue(isDraftApplicationAddedToContext);
            Assert.AreEqual(OutputPortInvokedMethod.Standard, useCaseOutput.InvokedOutputMethod);
        }

        [Test]
        public void AttachmentsWithUnallowedExtension_DraftNotCreated()
        {
            AssertApplicationLayerException<UnallowedFileExtensionException>(() =>
                this.CreateUseCaseWithRequiredFields(new List<string> {"testFile.exe"}));
        }

        [Test]
        public void AttachmentsWithoutExtension_DraftNotCreated()
        {
            AssertApplicationLayerException<FileExtensionNotRecognizedException>(() =>
                this.CreateUseCaseWithRequiredFields(new List<string> {"testFile"}));
        }

        private CreateDraftApplicationInput CreateUseCaseWithRequiredFields(List<string> fileNames = null)
        {
            var title = FakeData.AlphaNumeric(10);
            var description = FakeData.AlphaNumeric(99);
            var incidentType = IncidentType.AdverseEffectForTheCompany;
            var suspiciousEmployees = new List<Guid> {Guid.NewGuid()};
            var attachments = fileNames
                ?.Select(x => new FileData(x, new byte[] {0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20})).ToList();

            return new CreateDraftApplicationInput(
                title,
                description,
                incidentType,
                suspiciousEmployees,
                attachments);
        }
    }
}
