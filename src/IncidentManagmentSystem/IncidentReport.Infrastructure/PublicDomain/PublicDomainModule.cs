using Autofac;

namespace IncidentReport.Infrastructure.PublicDomain
{
    internal class PublicDomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(this.ThisAssembly)
                .Where(x => x.IsAssignableTo<IQuery>())
                .AsSelf();
        }
    }
}
