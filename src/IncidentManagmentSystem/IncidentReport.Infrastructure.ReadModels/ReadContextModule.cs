using System;
using Autofac;
using IncidentReport.ReadModels.Contract;
using Microsoft.EntityFrameworkCore;

namespace IncidentReport.ReadModels
{
    public class ReadContextModule : Autofac.Module
    {
        private readonly DbContextOptionsBuilder _dbContextOptions;

        public ReadContextModule(Action<DbContextOptionsBuilder> optionsAction)
        {
            this._dbContextOptions = new DbContextOptionsBuilder();
            optionsAction(this._dbContextOptions);
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder
                .Register(c => new IncidentReportReadDbContext(this._dbContextOptions.Options))
                .As<IncidentReportReadDbContext>()
                .AsSelf()
                .InstancePerLifetimeScope();

            builder.RegisterType<IncidentReportReadContext>()
                .As<IIncidentReportReadContext>()
                .InstancePerLifetimeScope();
        }
    }
}
