using System;
using Autofac;
using BuildingBlocks.Application;
using Microsoft.EntityFrameworkCore;

namespace IncidentManagmentSystem.Web.Configuration.Modules.IncidentReports
{
    public static class TestIncidentReportInitialize
    {
        public static void Init(ContainerBuilder builder, ICurrentUserContext currentUserContext)
        {
            ModuleInitializer.Init(builder, currentUserContext, options => options.UseInMemoryDatabase(Guid.NewGuid().ToString()));
        }
    }
}
