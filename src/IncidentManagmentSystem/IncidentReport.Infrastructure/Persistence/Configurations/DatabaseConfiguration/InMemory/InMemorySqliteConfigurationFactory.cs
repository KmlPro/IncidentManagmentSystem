using System;
using System.Data.Common;
using EntityFramework.Exceptions.Sqlite;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace IncidentReport.Infrastructure.Persistence.Configurations.DatabaseConfiguration.InMemory
{
    public class InMemorySqliteConfigurationFactory
    {
        private DbConnection _dbConnection;

        public InMemorySqliteConfigurationFactory()
        {
            this._dbConnection = CreateInMemoryDatabaseConnection();
        }

        public Action<DbContextOptionsBuilder> Create()
        {
            return options =>
            {
                options.UseSqlite(this._dbConnection);
                options.UseExceptionProcessor();
                options.EnableSensitiveDataLogging();
                options.ConfigureWarnings(x =>x.Ignore(Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.AmbientTransactionWarning));
            };
        }

        private static DbConnection CreateInMemoryDatabaseConnection()
        {
            var connection = new SqliteConnection("Filename=:memory:");
            connection.OpenAsync().GetAwaiter().GetResult();
            return connection;
        }
    }
}
