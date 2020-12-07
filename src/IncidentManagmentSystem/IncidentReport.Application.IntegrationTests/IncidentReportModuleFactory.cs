using Autofac;
using IncidentReport.Application.IntegrationTests.Mocks;
using IncidentReport.Infrastructure.Contract;

namespace IncidentReport.Application.IntegrationTests
{
    public class IncidentReportModuleFactory
    {
        public static IIncidentReportModule SetupAndBuild()
        {
            var currentUserContext = new TestCurrentUserContext();
            var rootContainerBuilder = new ContainerBuilder();
            var incidentReportStartup =
                new IncidentReportStartupForTests();

            incidentReportStartup.Initialize(currentUserContext);

            incidentReportStartup.RegisterModuleContract(rootContainerBuilder);

            var container = rootContainerBuilder.Build();

            return container.Resolve<IIncidentReportModule>();
        }
    }
}
