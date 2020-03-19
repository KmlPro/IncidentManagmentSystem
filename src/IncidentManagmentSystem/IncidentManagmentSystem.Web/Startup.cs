using System.Reflection;
using Autofac;
using AutoMapper;
using IncidentManagmentSystem.Web.Configuration.Middlewares;
using IncidentManagmentSystem.Web.Configuration.Modules;
using IncidentManagmentSystem.Web.Users;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
