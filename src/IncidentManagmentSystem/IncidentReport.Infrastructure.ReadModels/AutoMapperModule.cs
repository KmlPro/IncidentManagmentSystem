using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autofac;
using AutoMapper;
using IncidentReport.ReadModels.AutoMapperConfiguration;

namespace IncidentReport.ReadModels
{
    public class AutoMapperModule : Autofac.Module
    {
        private readonly IEnumerable<Assembly> _assembliesToScan;

        public AutoMapperModule(IEnumerable<Assembly> assembliesToScan)
        {
            this._assembliesToScan = assembliesToScan;
        }

        public AutoMapperModule(params Assembly[] assembliesToScan) : this((IEnumerable<Assembly>)assembliesToScan) { }

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            var assembliesToScan = this._assembliesToScan as Assembly[] ?? this._assembliesToScan.ToArray();

            var allTypes = assembliesToScan
                .Where(a => !a.IsDynamic && a.GetName().Name != nameof(AutoMapper))
                .Distinct() // avoid AutoMapper.DuplicateTypeMapConfigurationException
                .SelectMany(a => a.DefinedTypes)
                .ToArray();

            var openTypes = new[]
            {
                typeof(IValueResolver<,,>), typeof(IMemberValueResolver<,,,>), typeof(ITypeConverter<,>),
                typeof(IValueConverter<,>), typeof(IMappingAction<,>)
            };

            foreach (var type in openTypes.SelectMany(openType =>
                allTypes.Where(t => t.IsClass && !t.IsAbstract && ImplementsGenericInterface(t.AsType(), openType))))
            {
                builder.RegisterType(type.AsType()).InstancePerDependency();
            }

            builder.Register<IReadModuleConfigurationProvider>(ctx =>
                new ReadModuleMapperConfiguration(cfg => cfg.AddMaps(assembliesToScan)));

            builder.Register<IReadModuleIMapper>(ctx => new ReadModuleMapper(ctx.Resolve<IReadModuleConfigurationProvider>(), ctx.Resolve))
                .InstancePerDependency();
        }

        private static bool ImplementsGenericInterface(Type type, Type interfaceType)
        {
            return IsGenericType(type, interfaceType) || type.GetTypeInfo().ImplementedInterfaces
                .Any(@interface => IsGenericType(@interface, interfaceType));
        }

        private static bool IsGenericType(Type type, Type genericType)
        {
            return type.GetTypeInfo().IsGenericType && type.GetGenericTypeDefinition() == genericType;
        }
    }
}
