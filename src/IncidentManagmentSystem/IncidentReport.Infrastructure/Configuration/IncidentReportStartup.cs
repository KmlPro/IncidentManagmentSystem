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
using IncidentReport.ReadModels.DIConfiguration;
using Microsoft.EntityFrameworkCore;
using ILogger = Serilog.ILogger;

//kbytner 07.09.2020 - Startup Class inspired by https://github.com/kgrzybek/modular-monolith-with-ddd/blob/master/src/Modules/Meetings/Infrastructure/Configuration/MeetingsStartup.cs
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
            ICurrentUserContext currentUserContext, ILogger logger, Action<ContainerBuilder> externalInstancesConfiguration)
        {
            if (externalInstancesConfiguration == null)
            {
                throw new ArgumentNullException(nameof(externalInstancesConfiguration));
            }

            externalInstancesConfiguration(this._containerBuilder);

            this.ConfigureCompositionRoot(
                dbContextOptionsBuilderAction,
                currentUserContext,
                logger);
        }

        public void RegisterModuleContract(ContainerBuilder builder)
        {
            builder.RegisterType<IncidentReportModule>()
                .As<IIncidentReportModule>()
                .InstancePerLifetimeScope();
        }

        public void RegisterReadContextContract(ContainerBuilder builder,Action<DbContextOptionsBuilder> dbContextOptionsBuilderAction)
        {
            builder.RegisterModule(new ReadContextModule(dbContextOptionsBuilderAction));
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
