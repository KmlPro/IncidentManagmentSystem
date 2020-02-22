using System;
using System.Reflection;
using Autofac;
using BuildingBlocks.Application;
using IncidentReport.Application.Common;
using IncidentReport.Infrastructure.Configuration.DIContainer;
using IncidentReport.Infrastructure.Configuration.Processing;
using IncidentReport.Infrastructure.Contract;
using IncidentReport.Infrastructure.FileStorage;
using IncidentReport.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace IncidentReport.Infrastructure.Configuration
{
    public class IncidentReportStartup
    {
        private readonly Assembly _assemblyWithMediatRComponentsImplementation;

        public IncidentReportStartup()
        {
            this._assemblyWithMediatRComponentsImplementation = typeof(IncidentReportApplicationAssembly).GetTypeInfo().Assembly;
        }

        public IncidentReportStartup(Assembly assemblyWithCommandsImplementation)
        {
            this._assemblyWithMediatRComponentsImplementation = assemblyWithCommandsImplementation;
        }
        public void Initialize(Action<DbContextOptionsBuilder> dbContextOptionsBuilderAction, ICurrentUserContext currentUserContext)
        {
            this.ConfigureCompositionRoot(
                dbContextOptionsBuilderAction,
                currentUserContext);
        }

        public void RegisterModuleContract(ContainerBuilder builder)
        {
            builder.RegisterType<IncidentReportModule>()
              .As<IIncidentReportModule>()
              .InstancePerLifetimeScope();
        }

        private void ConfigureCompositionRoot(Action<DbContextOptionsBuilder> dbContextOptionsBuilderAction, ICurrentUserContext currentUserContext)
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule(new MediatRModule(this._assemblyWithMediatRComponentsImplementation));
            containerBuilder.RegisterModule(new PersistanceModule(dbContextOptionsBuilderAction));
            containerBuilder.RegisterModule(new ProcessingModule());
            containerBuilder.RegisterModule(new FileStorageModule());

            containerBuilder.RegisterInstance(currentUserContext);

            var container = containerBuilder.Build();

            CompositionRoot.SetContainer(container);
        }
    }
}
