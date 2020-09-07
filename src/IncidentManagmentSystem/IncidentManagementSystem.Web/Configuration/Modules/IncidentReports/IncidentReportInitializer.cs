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
        private Action<DbContextOptionsBuilder> _dbContextOptionsBuilderAction;

        public IncidentReportInitializer()
        {
            this._initializer = new ModuleInitializer();
            this._dbContextOptionsBuilderAction = this.ConfigurePersistance();
        }

        public void Init(ICurrentUserContext currentUserContext, ILogger logger)
        {
            this._initializer.Init(currentUserContext, logger,options => options.UseInMemoryDatabase("IncidentReport"));
        }

        public void RegisterContracts(ContainerBuilder builder)
        {
            this._initializer.RegisterModuleContracts(builder, this._dbContextOptionsBuilderAction);
        }

        private Action<DbContextOptionsBuilder> ConfigurePersistance()
        {
            return options => options.UseInMemoryDatabase("IncidentReport");
        }
    }
}
