// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly:
    SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "<Pending>", Scope = "member",
        Target =
            "~M:IncidentManagmentSystem.Web.Startup.ConfigureServices(Microsoft.Extensions.DependencyInjection.IServiceCollection)")]
[assembly:
    SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "<Pending>", Scope = "member",
        Target = "~M:IncidentManagmentSystem.Web.Startup.ConfigureContainer(Autofac.ContainerBuilder)")]
[assembly:
    SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "<Pending>", Scope = "member",
        Target =
            "~M:IncidentManagmentSystem.Web.Startup.Configure(Microsoft.AspNetCore.Builder.IApplicationBuilder,Microsoft.AspNetCore.Hosting.IWebHostEnvironment)")]
[assembly:
    SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>",
        Scope = "member",
        Target =
            "~M:IncidentManagmentSystem.Web.UseCases.CreateDraftApplications.CreateDraftApplicationRequest.Mapping(AutoMapper.Profile)")]
[assembly:
    SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>",
        Scope = "member",
        Target =
            "~M:IncidentManagmentSystem.Web.UseCases.CreateDraftApplications.CreateDraftApplicationPresenter.Standard(IncidentReport.Application.Boundaries.CreateDraftApplications.CreateDraftApplicationOutput)")]
[assembly:
    SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>",
        Scope = "member",
        Target = "~M:IncidentManagmentSystem.Web.Configuration.Mappings.IMapTo`1.Mapping(AutoMapper.Profile)")]
[assembly: SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "<Pending>", Scope = "member", Target = "~M:IncidentManagmentSystem.Web.TestStartup.ConfigureContainer(Autofac.ContainerBuilder)")]
[assembly: SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "<Pending>", Scope = "member", Target = "~M:IncidentManagmentSystem.Web.TestStartup.Configure(Microsoft.AspNetCore.Builder.IApplicationBuilder,Microsoft.AspNetCore.Hosting.IWebHostEnvironment)")]
[assembly: SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "<Pending>", Scope = "member", Target = "~M:IncidentManagmentSystem.Web.TestStartup.ConfigureServices(Microsoft.Extensions.DependencyInjection.IServiceCollection)")]
