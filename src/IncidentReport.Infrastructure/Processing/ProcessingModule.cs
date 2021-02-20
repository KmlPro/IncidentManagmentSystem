using Autofac;
using BuildingBlocks.Infrastructure;
using IncidentReport.Infrastructure.Processing.UseCases;

namespace IncidentReport.Infrastructure.Processing
{
    internal class ProcessingModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UseCaseExecutor>().AsSelf();

            builder.RegisterType<UnitOfWork>()
                .As<IUnitOfWork>()
                .InstancePerLifetimeScope();
        }
    }
}
