using System;
using BuildingBlocks.Application;
using IncidentReport.Infrastructure.Configuration.DIContainer;
using Microsoft.EntityFrameworkCore;

namespace IncidentReport.Infrastructure.Configuration
{
    public class IncidentReportStartup
    {
        public static void Initialize(Action<DbContextOptionsBuilder> dbContextOptionsBuilderAction, ICurrentUserContext currentUserContext)
        {
            CompositionRoot.RegisterInstances(
                dbContextOptionsBuilderAction,
                currentUserContext);
        }
    }
}
