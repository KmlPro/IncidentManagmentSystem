using System;
using EntityFramework.Exceptions.SqlServer;
using Microsoft.EntityFrameworkCore;

namespace IncidentReport.Infrastructure.Persistence.Configurations.DatabaseConfiguration.RealConfiguration
{
    public class SqlServerConfigurationFactory
    {
        public Action<DbContextOptionsBuilder> Create(string connectionString)
        {
            return builder =>
            {
                builder.UseSqlServer(connectionString);
                builder.UseExceptionProcessor();
            };
        }
    }
}
