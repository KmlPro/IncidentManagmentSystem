using System;
using AutoMapper;

namespace IncidentReport.ReadModels.AutoMapperConfiguration
{
    public class ReadModuleMapper : Mapper, IReadModuleIMapper
    {
        public ReadModuleMapper(IConfigurationProvider configurationProvider) : base(configurationProvider)
        {
        }

        public ReadModuleMapper(IConfigurationProvider configurationProvider, Func<Type, object> serviceCtor) : base(configurationProvider, serviceCtor)
        {
        }
    }
}
