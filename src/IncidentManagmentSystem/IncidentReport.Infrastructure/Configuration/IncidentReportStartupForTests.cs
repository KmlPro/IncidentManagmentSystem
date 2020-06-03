using System;
using System.Reflection;
using BuildingBlocks.Application;
using Microsoft.EntityFrameworkCore;

namespace IncidentReport.Infrastructure.Configuration
{
    public class IncidentReportStartupForTests : IncidentReportStartup
    {
        private readonly Assembly _assemblyWithMediatRComponentsImplementationForTest;

        public IncidentReportStartupForTests(Assembly assemblyWithCommandsImplementation)
        {
            this._assemblyWithMediatRComponentsImplementationForTest = assemblyWithCommandsImplementation;
        }

        public void Initialize(Action<DbContextOptionsBuilder> dbContextOptionsBuilderAction,
            ICurrentUserContext currentUserContext)
        {
            this.AssemblyWithMediatRComponentsImplementation = this._assemblyWithMediatRComponentsImplementationForTest;
            this.Initialize(dbContextOptionsBuilderAction, currentUserContext, container => { });
        }
    }
}
