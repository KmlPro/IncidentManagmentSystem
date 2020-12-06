using Autofac;
using BuildingBlocks.Application;
using IncidentReport.Application.Boundaries.CreateDraftApplications;
using IncidentReport.Application.IntegrationTests.UseCases.CreateDraftApplication;
using IncidentReport.Infrastructure.Configuration;
using IncidentReport.Infrastructure.Persistence;
using IncidentReport.Infrastructure.Persistence.Configurations.DatabaseConfiguration;
using IncidentReport.Infrastructure.Persistence.Configurations.DatabaseConfiguration.InMemory;
using Serilog;

namespace IncidentReport.Application.IntegrationTests
{
    public class IncidentReportStartupForTests : IncidentReportStartup
    {
        private readonly DbConfiguration _databaseConfiguration;

        public IncidentReportStartupForTests()
        {
            this._databaseConfiguration = new DbConfiguration(InMemoryDatabaseProvider.Sqlite);
        }

        public void Initialize(ICurrentUserContext currentUserContext)
        {
            var logger = new LoggerConfiguration().CreateLogger();

            this.Initialize(this._databaseConfiguration, currentUserContext, logger, container =>
            {
                container.RegisterType<CreateDraftApplicationUseCaseOutputPort>().InstancePerLifetimeScope();
                container.Register<IOutputPort>(ctx => ctx.Resolve<CreateDraftApplicationUseCaseOutputPort>())
                    .InstancePerLifetimeScope();
            });

            var dbContext = InstanceResolver.Resolve<IncidentReportWriteDbContext>();
            dbContext.Database.EnsureCreated();
        }
    }
}
