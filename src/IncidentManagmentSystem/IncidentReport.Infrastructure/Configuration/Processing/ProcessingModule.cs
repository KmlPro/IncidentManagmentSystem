using Autofac;
using BuildingBlocks.Infrastructure;
using IncidentReport.Infrastructure.Configuration.Processing.Commands;

namespace IncidentReport.Infrastructure.Configuration.Processing
{
    internal class ProcessingModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CommandsExecutor>().AsSelf();

            builder.RegisterType<UnitOfWork>()
                .As<IUnitOfWork>()
                .InstancePerLifetimeScope();
        }
    }
}

