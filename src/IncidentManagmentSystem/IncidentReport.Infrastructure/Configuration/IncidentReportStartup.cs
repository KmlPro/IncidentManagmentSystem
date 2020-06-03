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
        private readonly ContainerBuilder _containerBuilder;

        public IncidentReportStartup()
        {
            this.AssemblyWithMediatRComponentsImplementation =
                typeof(IncidentReportApplicationAssembly).GetTypeInfo().Assembly;
            this._containerBuilder = new ContainerBuilder();
        }

        protected Assembly AssemblyWithMediatRComponentsImplementation { get; set; }

        public void Initialize(Action<DbContextOptionsBuilder> dbContextOptionsBuilderAction,
            ICurrentUserContext currentUserContext, Action<ContainerBuilder> externalInstancesConfiguration)
        {
            if (externalInstancesConfiguration == null)
            {
                throw new ArgumentNullException(nameof(externalInstancesConfiguration));
            }

            externalInstancesConfiguration(this._containerBuilder);

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

        private void ConfigureCompositionRoot(Action<DbContextOptionsBuilder> dbContextOptionsBuilderAction,
            ICurrentUserContext currentUserContext)
        {
            this._containerBuilder.RegisterModule(new MediatRModule(this.AssemblyWithMediatRComponentsImplementation));
            this._containerBuilder.RegisterModule(new PersistanceModule(dbContextOptionsBuilderAction));
            this._containerBuilder.RegisterModule(new ProcessingModule());
            this._containerBuilder.RegisterModule(new FileStorageModule());

            this._containerBuilder.RegisterInstance(currentUserContext);

            var container = this._containerBuilder.Build();

            CompositionRoot.SetContainer(container);
        }
    }
}
