using NUnit.Framework;

namespace IncidentReport.Application.UnitTests.UseCases.UpdateDraftApplication
{
    [Category(CategoryTitle.Title)]
    public class UpdateDraftApplicationUseCaseTests : BaseTest
    {
        //[Test]
        //public async Task AllFieldsAreFilled_WithoutAttachments_SuspiciousEmployeeNotChanged_DraftUpdatedSuccessfully()
        //{
        //    //Arrange
        //    var suspiciousEmployees = new List<Guid> { Guid.NewGuid() };
        //    var incidentType = IncidentType.AdverseEffectForTheCompany;

        //    var newDraftApplication = this.AddNewDraftAplicationToContext(suspiciousEmployees, incidentType);

        //    var useCase = this.CreateUseCaseWithRequiredFields();
        //    var outputPort = new UpdateDraftApplicationUseCaseOutputPort();
        //    var handler = new UpdateDraftApplicationUseCase(this.IncidentReportDbContext,
        //        this.IFileStorageService, outputPort);

        //    //Act
        //    var useCaseOutput =
        //        (UpdateDraftApplicationUseCaseOutputPort)await handler.Handle(useCase, new CancellationToken());

        //    //Assert
        //    var isDraftApplicationAddedToContext =
        //        this.IncidentReportDbContext.DraftApplications.Any(x => x.Id.Value == useCaseOutput.Id);

        //    Assert.IsTrue(isDraftApplicationAddedToContext);
        //    Assert.AreEqual(OutputPortInvokedMethod.Standard, useCaseOutput.InvokedOutputMethod);
        //}

        //private DraftApplication AddNewDraftAplicationToContext(List<Guid> suspiciousEmployees, IncidentType incidentType)
        //{
        //    var title = FakeData.AlphaNumeric(10);
        //    var description = FakeData.AlphaNumeric(99);
        //    var contentOfApplication = new ContentOfApplication(title, description);

        //    var draftApplication = new DraftApplication()
        //}

        //[Test]
        //public async Task AllFieldsAreFilled_WithAttachments_DraftCreatedSuccessfully()
        //{
        //    //Arrange
        //    var command = this.CreateUseCaseWithRequiredFields(new List<string> { "testFile.pdf" });
        //    var outputPort = new CreateDraftApplicationUseCaseOutputPort();
        //    var handler = new CreateDraftApplicationUseCase(this.IncidentReportDbContext, this.CurrentUserContext,
        //        this.IFileStorageService, outputPort);

        //    //Act
        //    var useCaseOutput =
        //        (CreateDraftApplicationUseCaseOutputPort)await handler.Handle(command, new CancellationToken());

        //    //Assert
        //    var isDraftApplicationAddedToContext =
        //        this.IncidentReportDbContext.DraftApplications.Any(x => x.Id.Value == useCaseOutput.Id);

        //    Assert.IsTrue(isDraftApplicationAddedToContext);
        //    Assert.AreEqual(OutputPortInvokedMethod.Standard, useCaseOutput.InvokedOutputMethod);
        //}

        //private UpdateDraftApplicationInput CreateUseCaseWithRequiredFields(List<string> fileNames = null)
        //{
        //    var title = FakeData.AlphaNumeric(10);
        //    var description = FakeData.AlphaNumeric(99);
        //    var incidentType = IncidentType.AdverseEffectForTheCompany;
        //    var suspiciousEmployees = new List<Guid> { Guid.NewGuid() };
        //    var attachments = fileNames
        //        ?.Select(x => new FileData(x, new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 })).ToList();

        //    return new UpdateDraftApplicationInput(
        //        title,
        //        description,
        //        incidentType,
        //        suspiciousEmployees,
        //        attachments);
        //}

        //private UpdateDraftApplicationInput CreateUseCaseWithRequiredFields(List<string> fileNames = null)
        //{
        //    var title = FakeData.AlphaNumeric(10);
        //    var description = FakeData.AlphaNumeric(99);
        //    var incidentType = IncidentType.AdverseEffectForTheCompany;
        //    var suspiciousEmployees = new List<Guid> { Guid.NewGuid() };
        //    var attachments = fileNames
        //        ?.Select(x => new FileData(x, new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 })).ToList();

        //    return new UpdateDraftApplicationInput(
        //        title,
        //        description,
        //        incidentType,
        //        suspiciousEmployees,
        //        attachments);
        //}
    }
}
