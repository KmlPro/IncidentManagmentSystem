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
        public static void SeedDataForTest(Action<IncidentReportWriteDbContext> seed)
        {
            using (var scope = CompositionRoot.BeginLifetimeScope())
            {
                if (!(scope.Resolve<DbContext>() is IncidentReportWriteDbContext dbContext))
                {
                    throw new TestDatabaseInitializerException(
                        "Can't resolve IncidentReportWriteDbContext from Module DI");
                }

                dbContext.Database.EnsureCreated();
                seed?.Invoke(dbContext);

                dbContext.SaveChanges();
            }
        }
    }
}
