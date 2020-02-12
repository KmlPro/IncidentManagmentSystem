using System;
using Autofac;
using BuildingBlocks.Application;
using IncidentReport.Infrastructure.Configuration.Mediation;
using IncidentReport.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace IncidentReport.Infrastructure.Configuration.DIContainer
{
    public static class CompositionRoot
    {
        public static void RegisterInstances(Action<DbContextOptionsBuilder> dbContextOptionsBuilderAction, ICurrentUserContext currentUserContext)
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule(new MediatRModule());
            containerBuilder.RegisterModule(new PersistanceModule(dbContextOptionsBuilderAction));

            containerBuilder.RegisterInstance(currentUserContext);

            containerBuilder.Build();
        }
    }
}
