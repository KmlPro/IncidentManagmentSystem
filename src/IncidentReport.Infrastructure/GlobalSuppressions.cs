// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly:
    SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "<Pending>", Scope = "member",
        Target =
            "~M:IncidentReport.Infrastructure.Configuration.IncidentReportStartup.RegisterModuleContract(Autofac.ContainerBuilder)")]
[assembly:
    SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>",
        Scope = "member",
        Target =
            "~M:IncidentReport.Infrastructure.Configuration.Processing.Pipeline.UnitOfWorkPipelineBehavior`2.Handle(`0,System.Threading.CancellationToken,MediatR.RequestHandlerDelegate{`1})~System.Threading.Tasks.Task{`1}")]
[assembly:
    SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>",
        Scope = "member",
        Target =
            "~M:IncidentReport.Infrastructure.Persistence.IncidentReportDbContext.OnModelCreating(Microsoft.EntityFrameworkCore.ModelBuilder)")]
