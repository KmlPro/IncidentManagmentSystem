using IncidentManagementSystem.Web.Configuration.Modules.IncidentReports;

namespace IncidentManagementSystem.ApiBehavioursTests.WebAppTestConfiguration.Modules.IncidentReport
{
    public class TestIncidentReportModuleInitializer : ModuleInitializer
    {
        public TestIncidentReportModuleInitializer()
        {
            this.IncidentReportStartup = new TestIncidentReportStartup();
        }
    }
}
