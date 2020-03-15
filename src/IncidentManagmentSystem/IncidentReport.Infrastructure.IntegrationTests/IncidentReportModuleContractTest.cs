using System.Threading.Tasks;
using Autofac;
using IncidentReport.Infrastructure.Configuration;
using IncidentReport.Infrastructure.Contract;
using IncidentReport.Infrastructure.IntegrationTests.Commands.VoidCommand;
using IncidentReport.Infrastructure.IntegrationTests.Commands.WithResult;
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
            var incidentReportStartup = new IncidentReportStartup(typeof(IncidentReportModuleContractTest).Assembly);

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
        public void SendTestCommand_TaskResultDiffrentThanFaulted_CommandSentSucessfully()
        {
            var incidentReportModule = this._container.Resolve<IIncidentReportModule>();
            var command = new TestCommand("Sample data");

            var result = incidentReportModule.ExecuteCommandAsync(command);

            Assert.AreNotEqual(TaskStatus.Faulted, result.Status);
        }


        [Test]
        public async Task SendTestCommandWithResult_TaskResultDiffrentThanFaulted_CommandSentSucessfully()
        {
            var incidentReportModule = this._container.Resolve<IIncidentReportModule>();
            var command = new TestCommandWithResult("Sample data");

            var result = await incidentReportModule.ExecuteCommandWithResultAsync(command);

            Assert.NotNull(result);
        }
    }
}
