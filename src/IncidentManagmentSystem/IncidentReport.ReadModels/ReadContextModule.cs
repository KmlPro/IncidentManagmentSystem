using System;
using Autofac;
using Microsoft.EntityFrameworkCore;

namespace IncidentReport.ReadModels
{
    public class ReadContextModule : Autofac.Module
    {
        private readonly DbContextOptions<IncidentReportReadDbContext>  _dbContextOptionsBuilderAction;

        public ReadContextModule(DbContextOptions<IncidentReportReadDbContext>  dbContextOptionsBuilderAction)
        {
            this._dbContextOptionsBuilderAction = dbContextOptionsBuilderAction;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<IncidentReportReadDbContext>().AsSelf()
                .InstancePerLifetimeScope();

            builder.Register(t => new IncidentReportReadDbContext(this._dbContextOptionsBuilderAction));

            builder.RegisterType<IncidentReportReadContext>()
                .As<IIncidentReportReadContext>()
                .InstancePerLifetimeScope();
        }
    }
}
