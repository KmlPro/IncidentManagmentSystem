using IncidentReport.Infrastructure.Configuration.DIContainer;

namespace IncidentReport.Infrastructure.Configuration
{
    public class IncidentReportStartup
    {
        public static void Initialize(IncidentReportStartupConfiguration incidentReportStartupConfiguration)
        {
            CompositionRoot.RegisterInstances(incidentReportStartupConfiguration.DbContextOptionsBuilderAction);
        }
    }
}
