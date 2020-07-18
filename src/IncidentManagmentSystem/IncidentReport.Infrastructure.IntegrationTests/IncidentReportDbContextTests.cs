using System;
using BuildingBlocks.Infrastructure;
using IncidentReport.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Options;
using NUnit.Framework;

namespace IncidentReport.Infrastructure.IntegrationTests
{
    [Category(CategoryTitle.Title)]
    public class IncidentReportDbContextTests
    {
        [Test]
        public void EnsureDatabaseCreated_CreatedSucessfuly()
        {
            var options = new DbContextOptionsBuilder<IncidentReportWriteDbContext>()
                .ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            var context = new IncidentReportWriteDbContext(options);

            context.Database.EnsureCreated();
        }

        [Test] public void CreateDbSchema_SqlServerDatabase_CreatedSucessfuly()
        {
            var options = new DbContextOptionsBuilder<IncidentReportWriteDbContext>()
                .ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>()
                .UseSqlServer("Server=localhost;Database=IncidentReportDb;User Id=sa;Password=<YourStrong@Passw0rd>;").Options;

            var context = new IncidentReportWriteDbContext(options);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
    }
}
