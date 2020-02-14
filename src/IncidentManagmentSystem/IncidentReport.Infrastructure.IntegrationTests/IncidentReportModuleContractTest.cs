using System.Threading.Tasks;
using Autofac;
using IncidentReport.Infrastructure.Configuration;
using IncidentReport.Infrastructure.Contract;
using IncidentReport.Infrastructure.IntegrationTests.Common.Commands;
using IncidentReport.Infrastructure.IntegrationTests.Common.Mocks;
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
            IncidentReportStartup.Initialize(options => options.UseInMemoryDatabase("IncidentReport"),
                currentUserContext);
            IncidentReportStartup.RegisterModuleContract(rootContainerBuilder);

            this._container = rootContainerBuilder.Build();
        }

        [Test]
        public void Resolve_IncidentReportModuleFromContainer_InstanceResolved()
        {
            var incidentReportModule = this._container.Resolve<IIncidentReportModule>();

            Assert.NotNull(incidentReportModule);
        }

        [Test]
        public void SendTestCommand_NonResult_CommandSentSucessfully()
        {
            var incidentReportModule = this._container.Resolve<IIncidentReportModule>();
            var command = new TestCommand("Sample data");

            var result = incidentReportModule.ExecuteCommandAsync(command);

            Assert.AreNotEqual(TaskStatus.Faulted, result.Status);
        }
    }
}
