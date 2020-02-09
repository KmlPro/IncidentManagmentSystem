using Autofac;
using MediatR.Extensions.Autofac.DependencyInjection;

namespace IncidentReport.Infrastructure.Configuration.Mediation
{
    internal class MediatRModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.AddMediatR(typeof(IncidentReportStartup).Assembly);
        }
    }
}
