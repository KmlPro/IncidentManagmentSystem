using System;
using Microsoft.EntityFrameworkCore;

namespace IncidentReport.Infrastructure.Persistence.Configurations.DatabaseConfiguration.InMemory
{
    public class InMemoryEfDatabaseConfigurationFactory
    {
        public Action<DbContextOptionsBuilder> Create()
        {
            return options =>
            {
                options.UseInMemoryDatabase("IncidentReport");
            };
        }
    }
}
