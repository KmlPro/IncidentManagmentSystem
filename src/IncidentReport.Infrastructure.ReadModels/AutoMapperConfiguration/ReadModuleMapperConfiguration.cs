using System;
using AutoMapper;
using AutoMapper.Configuration;

namespace IncidentReport.ReadModels.AutoMapperConfiguration
{
    public class ReadModuleMapperConfiguration : MapperConfiguration, IReadModuleConfigurationProvider
    {
        public ReadModuleMapperConfiguration(MapperConfigurationExpression configurationExpression) : base(configurationExpression)
        {
        }

        public ReadModuleMapperConfiguration(Action<IMapperConfigurationExpression> configure) : base(configure)
        {
        }
    }
}
