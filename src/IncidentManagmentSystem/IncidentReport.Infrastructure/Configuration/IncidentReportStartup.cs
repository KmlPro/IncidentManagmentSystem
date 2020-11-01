using System;
using System.Reflection;
using Autofac;
using BuildingBlocks.Application;
using IncidentReport.Application.Common;
using IncidentReport.Infrastructure.AuditLogs;
using IncidentReport.Infrastructure.Configuration.DIContainer;
using IncidentReport.Infrastructure.Configuration.Processing;
using IncidentReport.Infrastructure.Contract;
using IncidentReport.Infrastructure.FileStorage;
using IncidentReport.Infrastructure.Logging;
using IncidentReport.Infrastructure.Persistence.Configurations;
using IncidentReport.Infrastructure.Persistence.Configurations.DatabaseConfiguration;
using IncidentReport.ReadModels.DIConfiguration;
using Microsoft.EntityFrameworkCore;
using ILogger = Serilog.ILogger;

//kbytner 07.09.2020 - Startup Class inspired by https://github.com/kgrzybek/modular-monolith-with-ddd/blob/master/src/Modules/Meetings/Infrastructure/Configuration/MeetingsStartup.cs
namespace IncidentReport.Infrastructure.Configuration
{
    public class IncidentReportStartup
    {
        private readonly ContainerBuilder _containerBuilder;
        private readonly DatabaseContextOptionsFactory _databaseConfigurationFactory;

        public IncidentReportStartup()
        {
            this.AssemblyWithMediatRComponentsImplementation =
                typeof(IncidentReportApplicationAssembly).GetTypeInfo().Assembly;
            this._containerBuilder = new ContainerBuilder();
            this._databaseConfigurationFactory = new DatabaseContextOptionsFactory();
        }

        protected Assembly AssemblyWithMediatRComponentsImplementation { get; set; }

        public void Initialize(DbConfiguration databaseConfiguration,
            ICurrentUserContext currentUserContext, ILogger logger, Action<ContainerBuilder> externalInstancesConfiguration)
        {
            if (externalInstancesConfiguration == null)
            {
                throw new ArgumentNullException(nameof(externalInstancesConfiguration));
            }

            externalInstancesConfiguration(this._containerBuilder);

            var dbConfiguration = this._databaseConfigurationFactory.Create(databaseConfiguration);

            this.ConfigureCompositionRoot(
                dbConfiguration,
                currentUserContext,
                logger);
        }

        public void RegisterModuleContract(ContainerBuilder builder)
        {
            builder.RegisterType<IncidentReportModule>()
                .As<IIncidentReportModule>()
                .InstancePerLifetimeScope();
        }

        public void RegisterReadContextContract(ContainerBuilder builder, DbConfiguration databaseConfiguration)
        {
            var dbConfiguration = this._databaseConfigurationFactory.Create(databaseConfiguration);

            builder.RegisterModule(new ReadContextModule(dbConfiguration));
        }

        private void ConfigureCompositionRoot(Action<DbContextOptionsBuilder> dbContextOptionsBuilderAction,
            ICurrentUserContext currentUserContext,ILogger logger)
        {
            this.RegisterTypesInContainer(this._containerBuilder,dbContextOptionsBuilderAction, currentUserContext, logger);

            var container = this._containerBuilder.Build();

            CompositionRoot.SetContainer(container);
        }

        protected virtual void RegisterTypesInContainer(ContainerBuilder containerBuilder, Action<DbContextOptionsBuilder> dbContextOptionsBuilderAction, ICurrentUserContext currentUserContext,
            ILogger logger)
        {
            containerBuilder.RegisterModule(new LoggingModule(logger));
            containerBuilder.RegisterModule(new MediatRModule(this.AssemblyWithMediatRComponentsImplementation));
            containerBuilder.RegisterModule(new PersistanceModule(dbContextOptionsBuilderAction));
            containerBuilder.RegisterModule(new ProcessingModule());
            containerBuilder.RegisterModule(new FileStorageModule());
            containerBuilder.RegisterModule(new AuditLogModule());
            containerBuilder.RegisterInstance(currentUserContext);
        }
    }
}
