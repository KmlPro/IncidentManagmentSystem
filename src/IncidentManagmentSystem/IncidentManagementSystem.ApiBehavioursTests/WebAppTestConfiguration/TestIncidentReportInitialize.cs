using System;
using System.Data.Common;
using Autofac;
using BuildingBlocks.Application;
using IncidentManagementSystem.Web.Configuration;
using IncidentManagementSystem.Web.Configuration.Modules.IncidentReports;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace IncidentManagementSystem.ApiBehavioursTests.WebAppTestConfiguration
{
    public class TestIncidentReportInitialize
    {
        private ModuleInitializer _initializer;
        private DbConnection _dbConnection;

        public TestIncidentReportInitialize()
        {
            this._initializer = new ModuleInitializer();
            this._dbConnection = CreateInMemoryDatabaseConnection();
        }

        public void Init(ICurrentUserContext currentUserContext)
        {
            var logger = new LoggerConfiguration().CreateLogger();

            this._initializer.Init(currentUserContext, logger,this.ConfigurePersistance());
        }

        public void RegisterContracts(ContainerBuilder builder)
        {
            this._initializer.RegisterModuleContracts(builder, this.ConfigurePersistance());
        }

        private static DbConnection CreateInMemoryDatabaseConnection()
        {
            var connection = new SqliteConnection("Filename=:memory:");
            connection.Open();
            return connection;
        }

        private Action<DbContextOptionsBuilder> ConfigurePersistance()
        {
            return options =>
            {
                options.UseSqlite(this._dbConnection);
            };
        }
    }
}
