using System.IO;
using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
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
using Serilog;
using Serilog.Extensions.Autofac.DependencyInjection;

namespace IncidentManagementSystem.Web
{
    public class Startup
    {
        private IncidentReportInitializer _incidentReportInitializer;
        private readonly string _logPath;
        private ILifetimeScope _autofacContainer;

        public Startup()
        {
            this._incidentReportInitializer = new IncidentReportInitializer();
            this._logPath = Path.Combine(typeof(Startup).Assembly.GetName().Name, "Log.log");
        }

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
            builder.RegisterSerilog(this._logPath);
            this._incidentReportInitializer.RegisterContracts(builder);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            this._autofacContainer = app.ApplicationServices.GetAutofacRoot();
            var userContext = this.CreateUserContext();
            var logger = this.GetLogger();

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

            this._incidentReportInitializer.Init(userContext,logger);
        }

        private CurrentUserContext CreateUserContext()
        {
            var httpContextAccessor = this._autofacContainer.Resolve<IHttpContextAccessor>();
            var currentUserContext = new CurrentUserContext(httpContextAccessor);
            return currentUserContext;
        }

        //kbytner 08.09.2020 -- repair register/get logger from container
        private ILogger GetLogger()
        {
            var logger = this._autofacContainer.Resolve<ILogger>();
            return logger;
        }
    }
}
