using System.Data.Common;
using Autofac;
using IncidentReport.Infrastructure.ReadModels.IntegrationTests.NUnitTestLogger;
using IncidentReport.ReadModels.DIConfiguration;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace IncidentReport.Infrastructure.ReadModels.IntegrationTests
{
    public class TestContainer
    {
        private IContainer _container;
        private DbConnection _dbConnection;

        private static readonly ILoggerFactory _myLoggerFactory
            = LoggerFactory.Create(builder =>
            {
                builder.AddFilter((category, level) =>
                    category == DbLoggerCategory.Database.Command.Name
                    && level == LogLevel.Information);
                
                builder.AddConsole();
                builder.AddProvider(new NUnitLoggerProvider());
            });

        public TestContainer()
        {
            var builder =  new ContainerBuilder();
            this._dbConnection = CreateInMemoryDatabaseConnection();

            builder.RegisterModule(new ReadContextModule(optionsBuilder =>
            {
                optionsBuilder.UseSqlite(this._dbConnection);
                optionsBuilder.UseLoggerFactory(_myLoggerFactory);
                optionsBuilder.EnableSensitiveDataLogging();
            }));

            this._container = builder.Build();
        }

        public ILifetimeScope BeginLifetimeScope()
        {
            return this._container.BeginLifetimeScope();
        }

        private static DbConnection CreateInMemoryDatabaseConnection()
        {
            var connection = new SqliteConnection("Filename=:memory:");
            connection.Open();
            return connection;
        }
    }
}
