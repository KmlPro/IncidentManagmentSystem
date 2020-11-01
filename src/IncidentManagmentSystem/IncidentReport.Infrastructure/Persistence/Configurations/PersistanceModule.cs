using System;
using Autofac;
using BuildingBlocks.Infrastructure;
using IncidentReport.Domain.IncidentVerificationApplications.DraftApplications;
using IncidentReport.Domain.IncidentVerificationApplications.IncidentApplications;
using IncidentReport.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IncidentReport.Infrastructure.Persistence.Configurations
{
    internal class PersistanceModule : Module
    {
        private readonly DbContextOptionsBuilder _dbContextOptions;

        public PersistanceModule(Action<DbContextOptionsBuilder> optionsAction)
        {
            this._dbContextOptions = new DbContextOptionsBuilder();
            optionsAction(this._dbContextOptions);
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder
                .Register(c =>
                {
                    this._dbContextOptions
                        .ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>();

                    return new IncidentReportWriteDbContext(this._dbContextOptions.Options);
                })
                .As<DbContext>()
                .As<IncidentReportWriteDbContext>()
                .AsSelf()
                .InstancePerLifetimeScope();

            builder.RegisterType<IncidentApplicationRepository>().As<IIncidentApplicationRepository>();
            builder.RegisterType<DraftApplicationRepository>().As<IDraftApplicationRepository>();
        }
    }
}
