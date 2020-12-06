using Autofac;
using IncidentReport.Application.IntegrationTests.Mocks;

namespace IncidentReport.Application.IntegrationTests
{
    public class TestContainerBuilder
    {
        public static IContainer Build()
        {
            var currentUserContext = new MockCurrentUserContextFactory().CreateUserContext();
            var rootContainerBuilder = new ContainerBuilder();
            var incidentReportStartup =
                new IncidentReportStartupForTests(typeof(IncidentReportStartupForTests).Assembly);

            incidentReportStartup.Initialize(currentUserContext);

            incidentReportStartup.RegisterModuleContract(rootContainerBuilder);

            return rootContainerBuilder.Build();
        }
    }
}
