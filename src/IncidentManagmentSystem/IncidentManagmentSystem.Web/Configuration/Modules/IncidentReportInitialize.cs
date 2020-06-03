using Autofac;
using BuildingBlocks.Application;
using IncidentManagmentSystem.Web.UseCases.CreateDraftApplications;
using IncidentReport.Application.Boundaries.CreateDraftApplications;
using IncidentReport.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace IncidentManagmentSystem.Web.Configuration.Modules
{
    public static class IncidentReportInitialize
    {
        public static void Init(ContainerBuilder builder, ICurrentUserContext currentUserContext)
        {
            var incidentReportStartup = new IncidentReportStartup();

            incidentReportStartup.Initialize(options => options.UseInMemoryDatabase("IncidentReport"),
                currentUserContext,
                moduleContainerBuilder =>
                {
                    moduleContainerBuilder.RegisterType<CreateDraftApplicationPresenter>().InstancePerLifetimeScope();
                    moduleContainerBuilder.Register<IOutputPort>(ctx => ctx.Resolve<CreateDraftApplicationPresenter>())
                        .InstancePerLifetimeScope();
                });

            incidentReportStartup.RegisterModuleContract(builder);
        }
    }
}
