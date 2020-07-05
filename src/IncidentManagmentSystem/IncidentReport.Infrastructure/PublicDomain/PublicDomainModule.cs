using System.Linq;
using System.Reflection;
using Autofac;
using IncidentReport.Infrastructure.Contract;
using IncidentReport.Infrastructure.Persistence;

namespace IncidentReport.Infrastructure.PublicDomain
{
    internal class PublicDomainModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(this.ThisAssembly)
                .Where(t => t.GetTypeInfo().ImplementedInterfaces.Any(
                    i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IQuery<>)))
                .AsSelf().InstancePerLifetimeScope();

            builder.RegisterType<IncidentReportDbContext>()
                .AsSelf()
                .InstancePerLifetimeScope();

            builder.RegisterType<IncidentReportReadContext>()
                .As<IIncidentReportReadContext>()
                .InstancePerLifetimeScope();
        }
    }
}
