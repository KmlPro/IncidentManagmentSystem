using System;
using EntityFramework.Exceptions.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace IncidentReport.Infrastructure.Persistence.Configurations.DatabaseConfiguration.RealConfiguration
{
    public class SqliteConfigurationFactory
    {
        public Action<DbContextOptionsBuilder> Create(string connectionString)
        {
            return builder =>
            {
                builder.UseSqlite(connectionString);
                builder.UseExceptionProcessor();
            };
        }
    }
}
