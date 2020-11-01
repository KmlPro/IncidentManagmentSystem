using System;
using Microsoft.EntityFrameworkCore;

namespace IncidentReport.Infrastructure.Persistence.Configurations.DatabaseConfiguration
{
    public class SqlServerConfigurationFactory
    {
        public Action<DbContextOptionsBuilder> Create(string connectionString)
        {
            return builder => { builder.UseSqlServer(connectionString); };
        }
    }
}
