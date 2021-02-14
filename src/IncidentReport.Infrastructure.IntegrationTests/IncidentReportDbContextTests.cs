using System;
using System.Data.Common;
using BuildingBlocks.Infrastructure;
using IncidentReport.Infrastructure.Persistence;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NUnit.Framework;

namespace IncidentReport.Infrastructure.IntegrationTests
{
    [Category(CategoryTitle.Title)]
    public class IncidentReportDbContextTests
    {
        [Test]
        public void EnsureDatabaseCreated_CreatedSuccessfully()
        {
            var options = new DbContextOptionsBuilder<IncidentReportWriteDbContext>()
                .ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            var context = new IncidentReportWriteDbContext(options);

            context.Database.EnsureCreated();
        }

        //[Test]
        //public void CreateDbSchema_SqlServerDatabase_CreatedSuccessfully()
        //{
        //    var options = new DbContextOptionsBuilder<IncidentReportWriteDbContext>()
        //        .ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>()
        //        .UseSqlServer("Server=localhost;Database=IncidentReportDb;User EventId=sa;Password=<YourStrong@Passw0rd>;").Options;

        //    var context = new IncidentReportWriteDbContext(options);

        //    context.Database.EnsureDeleted();
        //    context.Database.EnsureCreated();
        //}

        [Test]
        public void CreateDbSchema_SqlLiteDatabase_CreatedSuccessfully()
        {
            var options = new DbContextOptionsBuilder<IncidentReportWriteDbContext>()
                .ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>()
                .UseSqlite(CreateSqlLiteInMemoryDatabase()).Options;

            var context = new IncidentReportWriteDbContext(options);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }

        private static DbConnection CreateSqlLiteInMemoryDatabase()
        {
            var connection = new SqliteConnection("Filename=:memory:");

            connection.Open();

            return connection;
        }
    }
}
