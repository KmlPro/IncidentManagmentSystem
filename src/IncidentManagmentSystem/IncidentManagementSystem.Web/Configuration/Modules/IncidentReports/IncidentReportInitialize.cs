using Autofac;
using BuildingBlocks.Application;
using Microsoft.EntityFrameworkCore;

namespace IncidentManagementSystem.Web.Configuration.Modules.IncidentReports
{
    public static class IncidentReportInitialize
    {
        public static void Init(ContainerBuilder builder, ICurrentUserContext currentUserContext)
        {
            ModuleInitializer.Init(builder, currentUserContext, options => options.UseInMemoryDatabase("IncidentReport"));
        }
    }
}
