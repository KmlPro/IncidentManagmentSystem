using System;
using Autofac;
using IncidentReport.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace IncidentReport.Infrastructure.ReadContext
{
    internal class PublicDomainModule : Autofac.Module
    {
        private readonly Action<DbContextOptionsBuilder> _dbContextOptionsBuilderAction;

        public PublicDomainModule(Action<DbContextOptionsBuilder> dbContextOptionsBuilderAction)
        {
            this._dbContextOptionsBuilderAction = dbContextOptionsBuilderAction;
        }

        protected override void Load(ContainerBuilder builder)
        {
            // builder.RegisterType<IncidentReportReadContext>()
            //     .As<IIncidentReportReadContext>()
            //     .InstancePerLifetimeScope();
            //
            // builder.RegisterAssemblyTypes(this.ThisAssembly)
            //     .Where(x => x.IsAssignableTo<IQuery>())
            //     .AsImplementedInterfaces();
            //
            // builder.Register<Func<Type, IQuery>>(x=>
            // {
            //     var ctx = x.Resolve<IComponentContext>();
            //     return t =>
            //     {
            //         var queryType = typeof(IQuery<>).MakeGenericType(t);
            //         return (IQuery)ctx.Resolve(queryType);
            //     };
            // });

            builder.RegisterModule(new PersistanceModule(this._dbContextOptionsBuilderAction));
        }
    }
}
