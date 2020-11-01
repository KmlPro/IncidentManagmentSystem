using System;
using Microsoft.EntityFrameworkCore;

namespace IncidentReport.Infrastructure.Persistence.Configurations.DatabaseConfiguration
{
    public class SqliteConfigurationFactory
    {
        public Action<DbContextOptionsBuilder> Create(string connectionString)
        {
            return builder => { builder.UseSqlite(connectionString); };
        }
    }
}
