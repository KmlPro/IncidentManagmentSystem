using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Autofac;
using AutoMapper;
using IncidentManagmentSystem.Web.Users;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace IncidentManagmentSystem.Web.JustForTests
{
    [SuppressMessage("ReSharper", "CA1822")]
    public class TestStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddControllers();

            services.AddHttpContextAccessor();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            //var httpContextAccessor = container.Resolve<IHttpContextAccessor>();
            var currentUserContext = new CurrentUserContext(new HttpContextAccessor());

            TestIncidentReportInitialize.Init(builder, currentUserContext);
        }

        public void Configure([CanBeNull] IApplicationBuilder app, [CanBeNull] IWebHostEnvironment env)
        {
            app.UseRouting();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
