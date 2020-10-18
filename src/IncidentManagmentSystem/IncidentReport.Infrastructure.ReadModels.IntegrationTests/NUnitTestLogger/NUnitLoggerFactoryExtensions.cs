using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;

//kbytner 18.10.2020 - inspiration https://github.com/MarshallMoorman/Extensions.Logging.NUnit
namespace IncidentReport.Infrastructure.ReadModels.IntegrationTests.NUnitTestLogger
{
    public static class NUnitLoggerFactoryExtensions
    {
        public static ILoggingBuilder AddNUnit(this ILoggingBuilder builder)
        {
            builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<ILoggerProvider, NUnitLoggerProvider>());

            return builder;
        }
    }
}
