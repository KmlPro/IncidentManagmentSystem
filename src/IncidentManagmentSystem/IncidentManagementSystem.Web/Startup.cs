using System.IO;
using System.Reflection;
using Autofac;
using AutoMapper;
using IncidentManagementSystem.Web.Configuration.Filters;
using IncidentManagementSystem.Web.Configuration.Modules.IncidentReports;
using IncidentManagementSystem.Web.Configuration.Odata;
using IncidentManagementSystem.Web.Users;
using IncidentManagementSystem.Web.Configuration.Middlewares;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog.Extensions.Autofac.DependencyInjection;

namespace IncidentManagementSystem.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(ValidateModelStateAttribute));
            });

            services.AddControllers(mvcOptions =>
                mvcOptions.EnableEndpointRouting = false);

            services.AddOData();

            services.AddHttpContextAccessor();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddSwaggerDocumentation();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            var logPath = Path.Combine(typeof(Startup).Assembly.GetName().Name, "Log.log");
            builder.RegisterSerilog(logPath);

            //var httpContextAccessor = container.Resolve<IHttpContextAccessor>();
            var currentUserContext = new CurrentUserContext(new HttpContextAccessor());

            IncidentReportInitialize.Init(builder, currentUserContext);
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

            app.UseMvc(routeBuilder =>
            {
                routeBuilder.Select().Filter();
                routeBuilder.MapODataServiceRoute("odata", "odata", EdmModelFactory.Create());
            });

            //app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
