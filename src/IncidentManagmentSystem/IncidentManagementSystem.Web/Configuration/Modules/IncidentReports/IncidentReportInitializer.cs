using System;
using Autofac;
using BuildingBlocks.Application;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace IncidentManagementSystem.Web.Configuration.Modules.IncidentReports
{
    public class IncidentReportInitializer
    {
        private ModuleInitializer _initializer;

        public IncidentReportInitializer()
        {
            this._initializer = new ModuleInitializer();
        }

        public void Init(ICurrentUserContext currentUserContext, ILogger logger)
        {
            this._initializer.Init(currentUserContext, logger);
        }

        public void RegisterContracts(ContainerBuilder builder)
        {
            this._initializer.RegisterModuleContracts(builder);
        }

        private Action<DbContextOptionsBuilder> ConfigurePersistance()
        {
            return options => options.UseInMemoryDatabase("IncidentReport");
        }
    }
}
