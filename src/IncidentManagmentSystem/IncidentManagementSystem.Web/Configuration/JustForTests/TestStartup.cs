using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Autofac;
using AutoMapper;
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
            services.AddMvc();
            services.AddControllers();

            services.AddHttpContextAccessor();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            this._initializer.RegisterContracts(builder);
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();
            app.UseEndpoints(endpoints => endpoints.MapControllers());

            var currentUserContext = new TestCurrentUserContext();
            this._initializer.Init(currentUserContext);
        }
    }
}
