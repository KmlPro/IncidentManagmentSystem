using System;
using BuildingBlocks.Infrastructure;
using IncidentReport.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NUnit.Framework;

namespace IncidentReport.Infrastructure.IntegrationTests
{
    [Category(CategoryTitle.Title)]
    public class IncidentReportDbContextTests
    {
        [Test]
        public void EnsureDatabaseCreated_CreatedSucessfuly()
        {
            var options = new DbContextOptionsBuilder<IncidentReportDbContext>()
                .ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            var context = new IncidentReportDbContext(options);

            context.Database.EnsureCreated();
        }
    }
}
