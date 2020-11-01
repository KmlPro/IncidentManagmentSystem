using Autofac;
using BuildingBlocks.Application;
using IncidentManagementSystem.Web.IncidentReports.UseCases.CreateDraftApplications;
using IncidentManagementSystem.Web.IncidentReports.UseCases.PostApplications;
using IncidentManagementSystem.Web.IncidentReports.UseCases.UpdateDraftApplications;
using IncidentReport.Application.Boundaries.CreateDraftApplications;
using IncidentReport.Infrastructure.Configuration;
using IncidentReport.Infrastructure.Persistence.Configurations.DatabaseConfiguration;
using Serilog;

namespace IncidentManagementSystem.Web.Configuration.Modules.IncidentReports
{
    public class ModuleInitializer
    {
        protected IncidentReportStartup IncidentReportStartup { get; set; }
        protected DbConfiguration DatabaseConfiguration { get; set; }
        public ModuleInitializer()
        {
            this.IncidentReportStartup = new IncidentReportStartup();
            this.DatabaseConfiguration = new DbConfiguration(InMemoryDatabaseProvider.Sqlite);
        }

        public void Init(ICurrentUserContext currentUserContext, ILogger logger)
        {
            var moduleLogger = logger.ForContext(LoggingConsts.ModuleParameter, LoggingConsts.IncidentReportModule);

            this.IncidentReportStartup.Initialize(this.DatabaseConfiguration,
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

        public void RegisterModuleContracts(ContainerBuilder builder)
        {
            this.IncidentReportStartup.RegisterModuleContract(builder);
            this.IncidentReportStartup.RegisterReadContextContract(builder, DatabaseConfiguration);
        }
    }
}
