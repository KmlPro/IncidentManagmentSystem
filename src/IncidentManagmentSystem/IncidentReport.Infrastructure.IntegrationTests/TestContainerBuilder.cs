using Autofac;
using IncidentReport.Infrastructure.Configuration;
using IncidentReport.Infrastructure.IntegrationTests.Mocks;
using Microsoft.EntityFrameworkCore;

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

            incidentReportStartup.Initialize(options => options.UseInMemoryDatabase("IncidentReport"),
                currentUserContext);

            incidentReportStartup.RegisterModuleContract(rootContainerBuilder);

            return rootContainerBuilder.Build();
        }
    }
}
