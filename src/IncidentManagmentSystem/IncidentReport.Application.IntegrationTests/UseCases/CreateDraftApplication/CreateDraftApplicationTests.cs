using System.Collections.Generic;
using System.Threading.Tasks;
using BuildingBlocks.Application.UnitTests;
using IncidentReport.Application.IntegrationTests.TestFixtures.EmployeesFixtures;
using IncidentReport.Domain.Employees.ValueObjects;
using IncidentReport.Domain.IncidentVerificationApplications.DraftApplications;
using IncidentReport.Infrastructure.Contract;
using NUnit.Framework;

namespace IncidentReport.Application.IntegrationTests.UseCases.CreateDraftApplication
{
    [Category(CategoryTitle.Title + " CreateDraftApplicationUseCase")]
    public class CreateDraftApplicationTests : BaseTest
    {
        private readonly TestFixture _testFixture;
        private readonly IIncidentReportModule _module;
        private EmployeeId _suspiciousEmployee;

        public CreateDraftApplicationTests()
        {
            this._module = IncidentReportModuleFactory.SetupAndBuild();
            var _repository = InstanceResolver.Resolve<IDraftApplicationRepository>();
            this._testFixture = new TestFixture(_repository);
            (_,this._suspiciousEmployee) = EmployeesTestFixture.PrepareApplicantAndRandomEmployeeInDb();
        }

        [Test]
        public async Task AllFieldsAreFilled_OnlyWithoutAttachments_DraftCreatedSuccessfully()
        {
            //Arrange
            var useCase = this._testFixture.CreateUseCaseWithRequiredFields(this._suspiciousEmployee.Value);

            //Act
            var useCaseOutput =
                (CreateDraftApplicationUseCaseOutputPort)await this._module.ExecuteUseCase(useCase);

            //Assert

            Assert.IsTrue(await this._testFixture.IsDraftApplicationAdded(useCaseOutput.Id));
            Assert.AreEqual(OutputPortInvokedMethod.Standard, useCaseOutput.InvokedOutputMethod);
        }

        [Test]
        public async Task AllFieldsAreFilled_WithAttachments_DraftCreatedSuccessfully()
        {
            //Arrange
            var useCase = this._testFixture.CreateUseCaseWithRequiredFields(this._suspiciousEmployee.Value,new List<string> {"testFile.pdf"});

            //Act
            var useCaseOutput =
                (CreateDraftApplicationUseCaseOutputPort)await this._module.ExecuteUseCase(useCase);

            //Assert
            Assert.IsTrue(await this._testFixture.IsDraftApplicationAdded(useCaseOutput.Id));
            Assert.AreEqual(OutputPortInvokedMethod.Standard, useCaseOutput.InvokedOutputMethod);
        }

        [Test]
        public async Task AttachmentsWithUnallowedExtension_DraftNotCreated()
        {
            var useCase = this._testFixture.CreateUseCaseWithRequiredFields(this._suspiciousEmployee.Value,new List<string> {"testFile.exe"});

            //Act
            var useCaseOutput =
                (CreateDraftApplicationUseCaseOutputPort)await this._module.ExecuteUseCase(useCase);

            //Assert

            Assert.AreEqual(OutputPortInvokedMethod.WriteInvalidInput, useCaseOutput.InvokedOutputMethod);
        }

        [Test]
        public async Task AttachmentsWithoutExtension_DraftNotCreated()
        {
            var useCase = this._testFixture.CreateUseCaseWithRequiredFields(this._suspiciousEmployee.Value,new List<string> {"testFile"});

            //Act
            var useCaseOutput =
                (CreateDraftApplicationUseCaseOutputPort)await this._module.ExecuteUseCase(useCase);

            //Assert
            Assert.AreEqual(OutputPortInvokedMethod.WriteInvalidInput, useCaseOutput.InvokedOutputMethod);
        }
    }
}
