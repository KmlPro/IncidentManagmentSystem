using System.Threading.Tasks;
using Autofac;
using IncidentReport.Infrastructure.Contract;
using IncidentReport.Infrastructure.IntegrationTests.UseCases;
using NUnit.Framework;

namespace IncidentReport.Infrastructure.IntegrationTests
{
    [Category(CategoryTitle.Title)]
    public class IncidentReportModuleContractTest
    {
        private readonly IContainer _container;

        public IncidentReportModuleContractTest()
        {
            this._container = TestContainerBuilder.Build();
        }

        [Test]
        public void Resolve_IncidentReportModuleFromContainer_InstanceResolved()
        {
            var incidentReportModule = this._container.Resolve<IIncidentReportModule>();

            Assert.NotNull(incidentReportModule);
        }

        [Test]
        public void ExecuteUseCase_TaskResultDiffrentThanFaulted_CommandSentSucessfully()
        {
            var incidentReportModule = this._container.Resolve<IIncidentReportModule>();
            var useCase = new TestUseCaseInput("Sample data");

            var result = incidentReportModule.ExecuteUseCase(useCase);

            Assert.AreNotEqual(TaskStatus.Faulted, result.Status);
        }
    }
}
