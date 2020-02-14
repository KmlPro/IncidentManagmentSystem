using System.Reflection;
using Autofac;
using AutoMapper;
using IncidentManagmentSystem.Web.Configuration.Middlewares;
using IncidentManagmentSystem.Web.Users;
using IncidentReport.Infrastructure.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace IncidentManagmentSystem.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddControllers();

            services.AddHttpContextAccessor();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddSwaggerDocumentation();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            var incidentReportStartup = new IncidentReportStartup();
            //var httpContextAccessor = container.Resolve<IHttpContextAccessor>();
            var currentUserContext = new CurrentUserContext(new HttpContextAccessor());

            incidentReportStartup.Initialize(options => options.UseInMemoryDatabase("IncidentReport"),
                currentUserContext);

            incidentReportStartup.RegisterModuleContract(builder);
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwaggerDocumentation();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
