using System;
using IncidentReport.Infrastructure.Persistence.Configurations.DatabaseConfiguration.InMemory;
using IncidentReport.Infrastructure.Persistence.Configurations.DatabaseConfiguration.RealConfiguration;
using Microsoft.EntityFrameworkCore;

namespace IncidentReport.Infrastructure.Persistence.Configurations.DatabaseConfiguration
{
    public class DatabaseContextOptionsFactory
    {
        private SqliteConfigurationFactory _sqlLite;
        private SqlServerConfigurationFactory _sqlServer;
        private InMemoryEfDatabaseConfigurationFactory _inMemoryEfDatabase;
        private InMemorySqliteConfigurationFactory _inMemorySqlite;

        public DatabaseContextOptionsFactory()
        {
            this._sqlLite = new SqliteConfigurationFactory();
            this._sqlServer = new SqlServerConfigurationFactory();
            this._inMemoryEfDatabase = new InMemoryEfDatabaseConfigurationFactory();
            this._inMemorySqlite = new InMemorySqliteConfigurationFactory();
        }

        public Action<DbContextOptionsBuilder> Create(DbConfiguration dbConfiguration)
        {
            if (dbConfiguration.DatabaseProvider.HasValue)
            {
                return this.GetConfigurationWithRealDatabase(dbConfiguration);
            }

            return this.GetConfigurationForInMemoryDatabase(dbConfiguration);
        }

        private Action<DbContextOptionsBuilder> GetConfigurationForInMemoryDatabase(DbConfiguration dbConfiguration)
        {
            return dbConfiguration.InMemoryDatabaseProvider switch
            {
                InMemoryDatabaseProvider.Sqlite => this._inMemorySqlite.Create(),
                InMemoryDatabaseProvider.EfCore => this._inMemoryEfDatabase.Create(),
                _ => throw new NotSupportedException("Not supported database provider")
            };
        }

        private Action<DbContextOptionsBuilder> GetConfigurationWithRealDatabase(DbConfiguration dbConfiguration)
        {
            return dbConfiguration.DatabaseProvider switch
            {
                DatabaseProvider.Sqlite => this._sqlLite.Create(dbConfiguration.ConnectionString),
                DatabaseProvider.SqlServer => this._sqlServer.Create(dbConfiguration.ConnectionString),
                _ => throw new NotSupportedException("Not supported database provider")
            };
        }
    }
}
