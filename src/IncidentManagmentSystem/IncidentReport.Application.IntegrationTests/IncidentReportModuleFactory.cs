using Autofac;
using IncidentReport.Application.Common;
using IncidentReport.Application.IntegrationTests.Mocks;
using IncidentReport.Infrastructure.Contract;

namespace IncidentReport.Application.IntegrationTests
{
    public class IncidentReportModuleFactory
    {
        public static IIncidentReportModule SetupAndBuild()
        {
            var currentUserContext = new MockCurrentUserContextFactory().CreateUserContext();
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
