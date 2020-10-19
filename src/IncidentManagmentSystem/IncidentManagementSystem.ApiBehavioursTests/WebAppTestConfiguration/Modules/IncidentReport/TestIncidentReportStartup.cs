using System;
using Autofac;
using BuildingBlocks.Application;
using IncidentManagementSystem.ApiBehavioursTests.FileStorage;
using IncidentReport.Application.Files;
using IncidentReport.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using ILogger = Serilog.ILogger;

namespace IncidentManagementSystem.ApiBehavioursTests.WebAppTestConfiguration.Modules.IncidentReport
{
    public class TestIncidentReportStartup : IncidentReportStartup
    {
        protected override void RegisterTypesInContainer(ContainerBuilder containerBuilder, Action<DbContextOptionsBuilder> dbContextOptionsBuilderAction, ICurrentUserContext currentUserContext,
            ILogger logger)
        {
            base.RegisterTypesInContainer(containerBuilder, dbContextOptionsBuilderAction, currentUserContext, logger );

            containerBuilder.RegisterType<MockFileStorageService>().As<IFileStorageService>();
        }
    }
}
