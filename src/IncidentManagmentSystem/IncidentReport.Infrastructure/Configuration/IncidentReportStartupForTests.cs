using System;
using System.Reflection;
using Autofac;
using BuildingBlocks.Application;
using Microsoft.EntityFrameworkCore;

namespace IncidentReport.Infrastructure.Configuration
{
    public class IncidentReportStartupForTests : IncidentReportStartup
    {
        private readonly Assembly _assemblyWithMediatRComponentsImplementationForTest;
        public IncidentReportStartupForTests(Assembly assemblyWithCommandsImplementation) : base()
        {
            this._assemblyWithMediatRComponentsImplementationForTest = assemblyWithCommandsImplementation;
        }

        public void Initialize(Action<DbContextOptionsBuilder> dbContextOptionsBuilderAction, ICurrentUserContext currentUserContext)
        {
            this.AssemblyWithMediatRComponentsImplementation = _assemblyWithMediatRComponentsImplementationForTest;
            this.Initialize(dbContextOptionsBuilderAction, currentUserContext, (ContainerBuilder container) => { });
        }
    }
}
