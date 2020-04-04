using System.Threading.Tasks;
using Autofac;
using IncidentReport.Infrastructure.Configuration;
using IncidentReport.Infrastructure.Contract;
using IncidentReport.Infrastructure.IntegrationTests.Common.Mocks;
using IncidentReport.Infrastructure.IntegrationTests.UseCases;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace IncidentReport.Infrastructure.IntegrationTests
{
    public class IncidentReportModuleContractTest
    {
        private readonly IContainer _container;
        public IncidentReportModuleContractTest()
        {
            var currentUserContext = new MockCurrentUserContextFactory().CreateUserContext();
            var rootContainerBuilder = new ContainerBuilder();
            var incidentReportStartup = new IncidentReportStartupForTests(typeof(IncidentReportModuleContractTest).Assembly);

            incidentReportStartup.Initialize(options => options.UseInMemoryDatabase("IncidentReport"),
                currentUserContext);

            incidentReportStartup.RegisterModuleContract(rootContainerBuilder);

            this._container = rootContainerBuilder.Build();
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
