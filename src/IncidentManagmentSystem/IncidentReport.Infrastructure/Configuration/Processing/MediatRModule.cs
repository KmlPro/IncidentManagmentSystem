using System.Reflection;
using Autofac;
using IncidentReport.Infrastructure.Configuration.Processing.Behaviors;
using MediatR;
using Module = Autofac.Module;

namespace IncidentReport.Infrastructure.Configuration.Processing
{
    // sample configuration https://github.com/jbogard/MediatR/blob/master/samples/MediatR.Examples.Autofac/Program.cs
    internal class MediatRModule : Module
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

            var mediatrOpenTypes = new[] {typeof(IRequestHandler<,>)};

            foreach (var mediatrOpenType in mediatrOpenTypes)
            {
                builder
                    .RegisterAssemblyTypes(this._assemblyWithMediatRComponentsImplementation)
                    .AsClosedTypesOf(mediatrOpenType)
                    .AsImplementedInterfaces();
            }

            builder.RegisterGeneric(typeof(PerformanceBehaviour<,>)).As(typeof(IPipelineBehavior<,>));
            builder.RegisterGeneric(typeof(UnhandledExceptionBehaviour<,>)).As(typeof(IPipelineBehavior<,>));
            builder.RegisterGeneric(typeof(ResourceNotFoundBehaviour<,>)).As(typeof(IPipelineBehavior<,>));
            builder.RegisterGeneric(typeof(UnitOfWorkPipelineBehavior<,>)).As(typeof(IPipelineBehavior<,>));

            builder.Register<ServiceFactory>(ctx =>
            {
                var c = ctx.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            }).InstancePerLifetimeScope();
        }
    }
}
