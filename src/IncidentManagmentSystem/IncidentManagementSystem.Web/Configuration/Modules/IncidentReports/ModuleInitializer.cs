using System;
using Autofac;
using BuildingBlocks.Application;
using IncidentManagementSystem.Web.IncidentReports.UseCases.CreateDraftApplications;
using IncidentManagementSystem.Web.IncidentReports.UseCases.PostApplications;
using IncidentManagementSystem.Web.IncidentReports.UseCases.UpdateDraftApplications;
using IncidentReport.Application.Boundaries.CreateDraftApplications;
using IncidentReport.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace IncidentManagementSystem.Web.Configuration.Modules.IncidentReports
{
    public static class ModuleInitializer
    {
        //kbytner 07.09.2020 - split into two initializer (before asp net core interla container builder and after)
        public static void Init(ContainerBuilder builder, ICurrentUserContext currentUserContext, Action<DbContextOptionsBuilder> dbContextOptionsBuilderAction)
        {
            var incidentReportStartup = new IncidentReportStartup();
            var logger = new LoggerConfiguration().CreateLogger()
                .ForContext(LoggingConsts.ModuleParameter, LoggingConsts.IncidentReportModule);

            incidentReportStartup.Initialize(dbContextOptionsBuilderAction,
                currentUserContext,logger,
                moduleContainerBuilder =>
                {
                    moduleContainerBuilder.RegisterType<CreateDraftApplicationPresenter>().InstancePerLifetimeScope();
                    moduleContainerBuilder.Register<IOutputPort>(ctx => ctx.Resolve<CreateDraftApplicationPresenter>())
                        .InstancePerLifetimeScope();

                    moduleContainerBuilder.RegisterType<UpdateDraftApplicationPresenter>().InstancePerLifetimeScope();
                    moduleContainerBuilder.Register<IncidentReport.Application.Boundaries.UpdateDraftApplications.IOutputPort>(ctx => ctx.Resolve<UpdateDraftApplicationPresenter>())
                        .InstancePerLifetimeScope();

                    moduleContainerBuilder.RegisterType<PostApplicationPresenter>().InstancePerLifetimeScope();
                    moduleContainerBuilder.Register<IncidentReport.Application.Boundaries.PostApplicationUseCase.IOutputPort>(ctx => ctx.Resolve<PostApplicationPresenter>())
                        .InstancePerLifetimeScope();
                });

            incidentReportStartup.RegisterModuleContract(builder);
            incidentReportStartup.RegisterReadContextContract(builder, dbContextOptionsBuilderAction);
        }
    }
}
