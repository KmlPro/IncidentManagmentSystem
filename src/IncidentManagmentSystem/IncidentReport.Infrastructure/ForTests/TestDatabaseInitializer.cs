using System;
using Autofac;
using IncidentReport.Application.Common;
using IncidentReport.Infrastructure.Configuration.DIContainer;
using IncidentReport.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace IncidentReport.Infrastructure.ForTests
{
    public static class TestDatabaseInitializer
    {
        public static void SeedDataForTest(Action<IIncidentReportDbContext> seed)
        {
            using (var scope = CompositionRoot.BeginLifetimeScope())
            {
                var dbContext = scope.Resolve<DbContext>() as IncidentReportDbContext;
                seed?.Invoke(dbContext);

                dbContext.SaveChanges();
            }
        }
    }
}
