using System.Reflection;
using BuildingBlocks.Application;
using IncidentReport.Infrastructure.Configuration;
using IncidentReport.Infrastructure.Persistence.Configurations.DatabaseConfiguration;
using IncidentReport.Infrastructure.Persistence.Configurations.DatabaseConfiguration.InMemory;
using Serilog;

namespace IncidentReport.Infrastructure.IntegrationTests
{
    public class IncidentReportStartupForTests : IncidentReportStartup
    {
        private readonly Assembly _assemblyWithMediatRComponentsImplementationForTest;
        private readonly DbConfiguration _databaseConfiguration;

        public IncidentReportStartupForTests(Assembly assemblyWithCommandsImplementation)
        {
            this._assemblyWithMediatRComponentsImplementationForTest = assemblyWithCommandsImplementation;
            this._databaseConfiguration = new DbConfiguration(InMemoryDatabaseProvider.Sqlite);
        }

        public void Initialize(ICurrentUserContext currentUserContext)
        {
            var logger = new LoggerConfiguration().CreateLogger();

            this.AssemblyWithMediatRComponentsImplementation = this._assemblyWithMediatRComponentsImplementationForTest;
            this.Initialize(this._databaseConfiguration, currentUserContext, logger,container => { });
        }
    }
}
