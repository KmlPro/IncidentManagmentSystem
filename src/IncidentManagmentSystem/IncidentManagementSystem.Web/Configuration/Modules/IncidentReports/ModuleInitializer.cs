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
    public class ModuleInitializer
    {
        protected IncidentReportStartup IncidentReportStartup { get; set; }

        public ModuleInitializer()
        {
            this.IncidentReportStartup = new IncidentReportStartup();
        }

        public void Init(ICurrentUserContext currentUserContext, ILogger logger,
            Action<DbContextOptionsBuilder> dbContextOptionsBuilderAction)
        {
            var moduleLogger = logger.ForContext(LoggingConsts.ModuleParameter, LoggingConsts.IncidentReportModule);

            this.IncidentReportStartup.Initialize(dbContextOptionsBuilderAction,
                currentUserContext, moduleLogger,
                moduleContainerBuilder =>
                {
                    moduleContainerBuilder.RegisterType<CreateDraftApplicationPresenter>().InstancePerLifetimeScope();
                    moduleContainerBuilder.Register<IOutputPort>(ctx => ctx.Resolve<CreateDraftApplicationPresenter>())
                        .InstancePerLifetimeScope();

                    moduleContainerBuilder.RegisterType<UpdateDraftApplicationPresenter>().InstancePerLifetimeScope();
                    moduleContainerBuilder
                        .Register<IncidentReport.Application.Boundaries.UpdateDraftApplications.IOutputPort>(ctx =>
                            ctx.Resolve<UpdateDraftApplicationPresenter>())
                        .InstancePerLifetimeScope();

                    moduleContainerBuilder.RegisterType<PostApplicationPresenter>().InstancePerLifetimeScope();
                    moduleContainerBuilder
                        .Register<IncidentReport.Application.Boundaries.PostApplicationUseCase.IOutputPort>(ctx =>
                            ctx.Resolve<PostApplicationPresenter>())
                        .InstancePerLifetimeScope();
                });
        }

        public void RegisterModuleContracts(ContainerBuilder builder,
            Action<DbContextOptionsBuilder> dbContextOptionsBuilderAction)
        {
            this.IncidentReportStartup.RegisterModuleContract(builder);
            this.IncidentReportStartup.RegisterReadContextContract(builder, dbContextOptionsBuilderAction);
        }
    }
}
