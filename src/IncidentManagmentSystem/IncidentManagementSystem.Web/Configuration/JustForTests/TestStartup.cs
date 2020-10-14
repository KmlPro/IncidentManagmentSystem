using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Autofac;
using AutoMapper;
using IncidentManagementSystem.Web.Configuration.Filters;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace IncidentManagementSystem.Web.Configuration.JustForTests
{
    [SuppressMessage("ReSharper", "CA1822")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class TestStartup
    {
        private TestIncidentReportInitialize _initializer;

        public TestStartup()
        {
            this._initializer = new TestIncidentReportInitialize();
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

            services.AddHealthChecks();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            this._initializer.RegisterContracts(builder);
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("api/health");
                endpoints.MapControllers();
                endpoints.EnableDependencyInjection();
                endpoints.Select().Filter().OrderBy().Count().MaxTop(10);
            });

            var currentUserContext = new TestCurrentUserContext();
            this._initializer.Init(currentUserContext);
        }
    }
}
