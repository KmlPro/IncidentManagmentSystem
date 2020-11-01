using System;
using System.Data.Common;
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
            };
        }

        private static DbConnection CreateInMemoryDatabaseConnection()
        {
            var connection = new SqliteConnection("Filename=:memory:");
            connection.Open();
            return connection;
        }
    }
}
