using System.Data.Common;
using Autofac;
using BuildingBlocks.Application;
using IncidentManagmentSystem.Web.Configuration.Modules.IncidentReports;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace IncidentManagmentSystem.Web.JustForTests
{
    public static class TestIncidentReportInitialize
    {
        public static void Init(ContainerBuilder builder, ICurrentUserContext currentUserContext)
        {
            var connection = CreateInMemoryDatabaseConnection();

            ModuleInitializer.Init(builder, currentUserContext, options =>
            {
                options.UseSqlite(connection);
            });
        }

        private static DbConnection CreateInMemoryDatabaseConnection()
        {
            var connection = new SqliteConnection("Filename=:memory:");
            connection.Open();
            return connection;
        }
    }
}
