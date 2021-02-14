using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using IncidentManagementSystem.Web.Configuration.Filters;
using IncidentManagementSystem.Web.Configuration.Modules.IncidentReports;
using IncidentManagementSystem.Web.Users;
using IncidentManagementSystem.Web.Configuration.Middlewares;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Formatting.Compact;

namespace IncidentManagementSystem.Web
{
    public class Startup
    {
        private IncidentReportInitializer _incidentReportInitializer;
        private ILifetimeScope _autofacContainer;

        public Startup()
        {
            this._incidentReportInitializer = new IncidentReportInitializer();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(ValidateModelStateAttribute));
            });

            services.AddControllers(mvcOptions =>
                mvcOptions.EnableEndpointRouting = false).AddNewtonsoftJson();

            services.AddOData();

            services.AddHttpContextAccessor();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddSwaggerDocumentation();

            services.AddHealthChecks();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            this._incidentReportInitializer.RegisterContracts(builder);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            this._autofacContainer = app.ApplicationServices.GetAutofacRoot();
            var userContext = this.CreateUserContext();
            var logger = this.ConfigureLogger();

            app.UseSwaggerDocumentation();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("api/health");
                endpoints.MapControllers();
                endpoints.EnableDependencyInjection();
                endpoints.Select().Filter().OrderBy().Count().MaxTop(10);
            });

            this._incidentReportInitializer.Init(userContext,logger);
        }

        private CurrentUserContext CreateUserContext()
        {
            var httpContextAccessor = this._autofacContainer.Resolve<IHttpContextAccessor>();
            var currentUserContext = new CurrentUserContext(httpContextAccessor);
            return currentUserContext;
        }

        private ILogger ConfigureLogger()
        {
            return new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Console(
                    outputTemplate:
                    "[{Timestamp:HH:mm:ss} {Level:u3}] [{Module}] [{Context}] {Message:lj}{NewLine}{Exception}")
                .WriteTo.RollingFile(new CompactJsonFormatter(), "logs/logs")
                .CreateLogger();
        }
    }
}
