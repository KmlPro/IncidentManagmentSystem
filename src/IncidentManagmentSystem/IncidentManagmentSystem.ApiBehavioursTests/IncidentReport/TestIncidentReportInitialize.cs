using System;
using Autofac;
using BuildingBlocks.Application;
using IncidentManagmentSystem.Web.Configuration.Modules.IncidentReports;
using Microsoft.EntityFrameworkCore;

namespace IncidentManagmentSystem.ApiBehavioursTests.IncidentReport
{
    public static class TestIncidentReportInitialize
    {
        public static void Init(ContainerBuilder builder, ICurrentUserContext currentUserContext)
        {
            ModuleInitializer.Init(builder, currentUserContext, options => options.UseInMemoryDatabase(Guid.NewGuid().ToString()));
        }
    }
}
