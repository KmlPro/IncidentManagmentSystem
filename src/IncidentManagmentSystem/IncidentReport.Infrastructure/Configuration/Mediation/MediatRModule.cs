using System.Reflection;
using Autofac;
using MediatR;

namespace IncidentReport.Infrastructure.Configuration.Mediation
{
    // sample configuration https://github.com/jbogard/MediatR/blob/master/samples/MediatR.Examples.Autofac/Program.cs
    internal class MediatRModule : Autofac.Module
    {
        private readonly Assembly _assemblyWithMediatRComponentsImplementation;
        public MediatRModule(Assembly assemblyWithMediatRComponentsImplementation)
        {
            this._assemblyWithMediatRComponentsImplementation = assemblyWithMediatRComponentsImplementation;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            var mediatrOpenTypes = new[]
            {
                typeof(IRequestHandler<,>),
            };

            foreach (var mediatrOpenType in mediatrOpenTypes)
            {
                builder
                    .RegisterAssemblyTypes(this._assemblyWithMediatRComponentsImplementation)
                    .AsClosedTypesOf(mediatrOpenType)
                    .AsImplementedInterfaces();
            }

            builder.Register<ServiceFactory>(ctx =>
            {
                var c = ctx.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            }).InstancePerLifetimeScope();
        }
    }
}
