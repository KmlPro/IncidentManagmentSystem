using IncidentManagementSystem.Web.Configuration.Modules.IncidentReports;
using IncidentReport.Infrastructure.Persistence.Configurations.DatabaseConfiguration;
using IncidentReport.Infrastructure.Persistence.Configurations.DatabaseConfiguration.InMemory;

namespace IncidentManagementSystem.ApiBehavioursTests.WebAppTestConfiguration.Modules.IncidentReport
{
    public class TestIncidentReportModuleInitializer : ModuleInitializer
    {
        public TestIncidentReportModuleInitializer()
        {
            this.IncidentReportStartup = new TestIncidentReportStartup();
            this.DatabaseConfiguration = new DbConfiguration(InMemoryDatabaseProvider.Sqlite);
        }
    }
}
