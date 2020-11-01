using Autofac;
using BuildingBlocks.Application;
using Serilog;

namespace IncidentManagementSystem.ApiBehavioursTests.WebAppTestConfiguration.Modules.IncidentReport
{
    public class TestIncidentReportInitialize
    {
        private TestIncidentReportModuleInitializer _initializer;
        public TestIncidentReportInitialize()
        {
            this._initializer = new TestIncidentReportModuleInitializer();
        }

        public void Init(ICurrentUserContext currentUserContext)
        {
            var logger = new LoggerConfiguration().CreateLogger();

            this._initializer.Init(currentUserContext, logger);
        }

        public void RegisterContracts(ContainerBuilder builder)
        {
            this._initializer.RegisterModuleContracts(builder);
        }
    }
}
