using System.Collections.Generic;
using System.Threading.Tasks;
using BuildingBlocks.Application.UnitTests;
using IncidentReport.Application.Files;
using IncidentReport.Application.IntegrationTests.Factories;
using IncidentReport.Application.IntegrationTests.TestFixtures.EmployeesFixtures;
using IncidentReport.Domain.Aggregates.DraftApplications;
using IncidentReport.Domain.Entities.Attachments;
using IncidentReport.Domain.Entities.Employees.ValueObjects;
using IncidentReport.Infrastructure.Contract;
using NUnit.Framework;

namespace IncidentReport.Application.IntegrationTests.UseCases.UpdateDraftApplication
{
    [Category(CategoryTitle.Title + " UpdateDraftApplicationUseCase")]
    public class UpdateDraftApplicationTests : BaseTest
    {
        private TestFixture _testFixture;
        private readonly IIncidentReportModule _module;
        private EmployeeId _suspiciousEmployee;
        private EmployeeId _applicant;

        public UpdateDraftApplicationTests()
        {
            this._module = IncidentReportModuleFactory.SetupAndBuild();
            var _repository = InstanceResolver.Resolve<IDraftApplicationRepository>();
            this._testFixture = new TestFixture(_repository);
            (this._applicant, this._suspiciousEmployee) = EmployeesTestFixture.PrepareApplicantAndRandomEmployeeInDb();
        }

        [SetUp]
        public void Init()
        {
        }

        [Test]
        public async Task SuspiciousEmployeeNotChanged_DraftUpdatedSuccessfully()
        {
            //Arrange
            var initialSuspiciousEmployees = new List<EmployeeId> {this._suspiciousEmployee};
            var suspiciousEmployees = initialSuspiciousEmployees;

            var useCase = await this._testFixture.PrepareUseCaseWithTestData(this._applicant, suspiciousEmployees,
                initialSuspiciousEmployees);

            //Act
            var useCaseOutput =
                (UpdateDraftApplicationUseCaseOutputPort)await this._module.ExecuteUseCase(useCase);

            //Assert
            var draftApplicationFromContext = await this._testFixture.GetDraftFromContext(useCase.DraftApplicationId);

            Assert.AreEqual(OutputPortInvokedMethod.Standard, useCaseOutput.InvokedOutputMethod);
            Assert.AreEqual(1, draftApplicationFromContext.SuspiciousEmployees.Count);
        }

        [Test]
        public async Task TwoNewSuspiciousEmployeeAdded_OneRemoved_DraftUpdatedSuccessfully()
        {
            //Arrange
            var initialSuspiciousEmployees = new List<EmployeeId> {this._suspiciousEmployee};
            var newSuspiciousEmployees = EmployeesTestFixture.CreateRandomEmployeeInDb(2);

            var useCase =
                await this._testFixture.PrepareUseCaseWithTestData(this._applicant, newSuspiciousEmployees,
                    initialSuspiciousEmployees);

            //Act
            var useCaseOutput =
                (UpdateDraftApplicationUseCaseOutputPort)await this._module.ExecuteUseCase(useCase);

            //Assert
            var draftApplicationFromContext = await this._testFixture.GetDraftFromContext(useCase.DraftApplicationId);

            Assert.AreEqual(OutputPortInvokedMethod.Standard, useCaseOutput.InvokedOutputMethod);
            Assert.AreEqual(2, draftApplicationFromContext.SuspiciousEmployees.Count);
        }

        [Test]
        public async Task OneInitialAttachment_TwoAdded_ThreeAttachmentsInDraft()
        {
            //Arrange
            var initialAttachment = new List<Attachment> {AttachmentFactory.Create()};
            var addedAttachment = new List<FileData> {FileDataFactory.Create(), FileDataFactory.Create()};
            var initialSuspiciousEmployees = new List<EmployeeId> {this._suspiciousEmployee};

            var useCase =
                await this._testFixture.PrepareUseCaseWithTestData(this._applicant, initialSuspiciousEmployees,
                    addedAttachment, null, initialAttachment);

            //Act
            var useCaseOutput =
                (UpdateDraftApplicationUseCaseOutputPort)await this._module.ExecuteUseCase(useCase);

            //Assert
            var draftApplicationFromContext = await this._testFixture.GetDraftFromContext(useCase.DraftApplicationId);

            Assert.AreEqual(OutputPortInvokedMethod.Standard, useCaseOutput.InvokedOutputMethod);
            Assert.AreEqual(3, draftApplicationFromContext.Attachments.Count);
        }
    }
}
