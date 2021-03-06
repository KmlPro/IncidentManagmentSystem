using System.Threading.Tasks;
using BuildingBlocks.Application.UnitTests;
using IncidentReport.Application.IntegrationTests.TestFixtures.EmployeesFixtures;
using IncidentReport.Domain.Aggregates.DraftApplications;
using IncidentReport.Domain.Aggregates.IncidentApplications;
using IncidentReport.Domain.Entities.Employees.ValueObjects;
using IncidentReport.Infrastructure.Contract;
using NUnit.Framework;

namespace IncidentReport.Application.IntegrationTests.UseCases.PostApplication
{
    [Category(CategoryTitle.Title + " PostApplicationUseCase")]
    public class PostApplicationUseCaseTests : BaseTest
    {
        private readonly TestFixture _testFixture;
        private readonly IIncidentReportModule _module;
        private EmployeeId _suspiciousEmployee;
        private EmployeeId _applicant;

        public PostApplicationUseCaseTests()
        {
            this._module = IncidentReportModuleFactory.SetupAndBuild();
            var incidentApplicationRepository = InstanceResolver.Resolve<IIncidentApplicationRepository>();
            var draftApplicationRepository = InstanceResolver.Resolve<IDraftApplicationRepository>();

            this._testFixture = new TestFixture(incidentApplicationRepository, draftApplicationRepository);
            (this._applicant,this._suspiciousEmployee) = EmployeesTestFixture.PrepareApplicantAndRandomEmployeeInDb();
        }

        [Test]
        public async Task WithoutDraftApplication_PostedSuccessfully()
        {
            var useCase = this._testFixture.CreateInput(this._suspiciousEmployee.Value, null);

            var useCaseOutput =
                (PostApplicationUseCaseOutputPort)await this._module.ExecuteUseCase(useCase);

            Assert.AreEqual(OutputPortInvokedMethod.Standard, useCaseOutput.InvokedOutputMethod);
            Assert.IsTrue(await this._testFixture.IsIncidentApplicationAdded(useCaseOutput.Id));
        }

        [Test]
        public async Task WithDraftApplication_PostedSuccessfully()
        {
            var draftApplicationId =
                this._testFixture.CreateDraftApplicationInDb(this._applicant, this._suspiciousEmployee);

            var useCase = this._testFixture.CreateInput(this._suspiciousEmployee.Value, draftApplicationId.Value);

            var useCaseOutput =
                (PostApplicationUseCaseOutputPort)await this._module.ExecuteUseCase(useCase);

            Assert.AreEqual(OutputPortInvokedMethod.Standard, useCaseOutput.InvokedOutputMethod);
            Assert.IsTrue(await this._testFixture.IsIncidentApplicationAdded(useCaseOutput.Id));
            Assert.IsFalse(await this._testFixture.IsDraftApplicationExists(draftApplicationId.Value));
        }
    }
}
