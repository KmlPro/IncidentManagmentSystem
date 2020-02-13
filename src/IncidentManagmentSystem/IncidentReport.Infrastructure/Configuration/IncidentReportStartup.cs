using System;
using Autofac;
using BuildingBlocks.Application;
using IncidentReport.Infrastructure.Configuration.DIContainer;
using IncidentReport.Infrastructure.Configuration.Mediation;
using IncidentReport.Infrastructure.Configuration.Processing;
using IncidentReport.Infrastructure.Contract;
using IncidentReport.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace IncidentReport.Infrastructure.Configuration
{
    public class IncidentReportStartup
    {
        public static void Initialize(Action<DbContextOptionsBuilder> dbContextOptionsBuilderAction, ICurrentUserContext currentUserContext)
        {
            ConfigureCompositionRoot(
                dbContextOptionsBuilderAction,
                currentUserContext);
        }

        public static void RegisterModuleContract(ContainerBuilder builder)
        {
            builder.RegisterType<IncidentReportModule>()
              .As<IIncidentReportModule>()
              .InstancePerLifetimeScope();
        }

        public static void ConfigureCompositionRoot(Action<DbContextOptionsBuilder> dbContextOptionsBuilderAction, ICurrentUserContext currentUserContext)
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule(new MediatRModule());
            containerBuilder.RegisterModule(new PersistanceModule(dbContextOptionsBuilderAction));
            containerBuilder.RegisterModule(new ProcessingModule());

            containerBuilder.RegisterInstance(currentUserContext);

            var container = containerBuilder.Build();

            CompositionRoot.SetContainer(container);
        }
    }
}
