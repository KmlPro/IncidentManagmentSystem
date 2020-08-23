using System.Data.Common;
using Autofac;
using BuildingBlocks.Application;
using IncidentManagementSystem.Web.Configuration.Modules.IncidentReports;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace IncidentManagementSystem.Web.Configuration.JustForTests
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
