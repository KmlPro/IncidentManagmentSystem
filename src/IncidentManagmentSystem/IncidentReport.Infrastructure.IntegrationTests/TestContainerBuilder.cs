using Autofac;
using IncidentReport.Infrastructure.IntegrationTests.Mocks;

namespace IncidentReport.Infrastructure.IntegrationTests
{
    public class TestContainerBuilder
    {
        public static IContainer Build()
        {
            var currentUserContext = new MockCurrentUserContextFactory().CreateUserContext();
            var rootContainerBuilder = new ContainerBuilder();
            var incidentReportStartup =
                new IncidentReportStartupForTests(typeof(IncidentReportModuleContractTest).Assembly);

            incidentReportStartup.Initialize(currentUserContext);

            incidentReportStartup.RegisterModuleContract(rootContainerBuilder);

            return rootContainerBuilder.Build();
        }
    }
}
