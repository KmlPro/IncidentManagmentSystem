using System;
using System.Data.Common;
using Autofac;
using BuildingBlocks.Application;
using IncidentManagmentSystem.Web.Configuration.Modules.IncidentReports;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace IncidentManagmentSystem.Web.JustForTests
{
    public static class TestIncidentReportInitialize
    {
        public static void Init(ContainerBuilder builder, ICurrentUserContext currentUserContext)
        {
            ModuleInitializer.Init(builder, currentUserContext, options =>
            {
                options.UseSqlite(CreateInMemoryDatabase());
            });
        }

        private static DbConnection CreateInMemoryDatabase()
        {
            var connection = new SqliteConnection("Filename=:memory:");

            connection.Open();

            return connection;
        }
    }
}
