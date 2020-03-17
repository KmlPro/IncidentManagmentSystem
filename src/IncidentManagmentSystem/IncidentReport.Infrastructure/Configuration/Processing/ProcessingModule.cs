using Autofac;
using BuildingBlocks.Infrastructure;
using IncidentReport.Infrastructure.Configuration.Processing.Commands;
using IncidentReport.Infrastructure.Configuration.Processing.UseCases;

namespace IncidentReport.Infrastructure.Configuration.Processing
{
    internal class ProcessingModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CommandsExecutor>().AsSelf();
            builder.RegisterType<UseCaseExecutor>().AsSelf();

            builder.RegisterType<UnitOfWork>()
                .As<IUnitOfWork>()
                .InstancePerLifetimeScope();
        }
    }
}

