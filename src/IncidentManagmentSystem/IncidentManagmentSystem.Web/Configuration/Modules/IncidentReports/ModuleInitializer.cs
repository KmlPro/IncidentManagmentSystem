using System;
using Autofac;
using BuildingBlocks.Application;
using IncidentManagmentSystem.Web.UseCases.CreateDraftApplications;
using IncidentManagmentSystem.Web.UseCases.UpdateDraftApplications;
using IncidentReport.Application.Boundaries.CreateDraftApplications;
using IncidentReport.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace IncidentManagmentSystem.Web.Configuration.Modules.IncidentReports
{
    public static class ModuleInitializer
    {
        public static void Init(ContainerBuilder builder, ICurrentUserContext currentUserContext, Action<DbContextOptionsBuilder> dbContextOptionsBuilderAction)
        {
            var incidentReportStartup = new IncidentReportStartup();

            incidentReportStartup.Initialize(dbContextOptionsBuilderAction,
                currentUserContext,
                moduleContainerBuilder =>
                {
                    moduleContainerBuilder.RegisterType<CreateDraftApplicationPresenter>().InstancePerLifetimeScope();
                    moduleContainerBuilder.Register<IOutputPort>(ctx => ctx.Resolve<CreateDraftApplicationPresenter>())
                        .InstancePerLifetimeScope();

                    moduleContainerBuilder.RegisterType<UpdateDraftApplicationPresenter>().InstancePerLifetimeScope();
                    moduleContainerBuilder.Register<IncidentReport.Application.Boundaries.UpdateDraftApplications.IOutputPort>(ctx => ctx.Resolve<UpdateDraftApplicationPresenter>())
                        .InstancePerLifetimeScope();
                });

            incidentReportStartup.RegisterModuleContract(builder);
            incidentReportStartup.RegisterReadContextContract(builder, dbContextOptionsBuilderAction);
        }
    }
}
