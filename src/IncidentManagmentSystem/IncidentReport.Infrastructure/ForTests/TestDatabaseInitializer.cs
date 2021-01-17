using System;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using IncidentReport.Infrastructure.Configuration.DIContainer;
using IncidentReport.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace IncidentReport.Infrastructure.ForTests
{
    public static class TestDatabaseInitializer
    {
        public static void SeedDataForTest(Action<IncidentReportWriteDbContext> seed)
        {
            using (var scope = CompositionRoot.BeginLifetimeScope())
            {
                var dbContext = scope.Resolve<IncidentReportWriteDbContext>();

                dbContext.Database.EnsureCreated();
                seed?.Invoke(dbContext);

                dbContext.SaveChanges();
            }
        }
    }
}
