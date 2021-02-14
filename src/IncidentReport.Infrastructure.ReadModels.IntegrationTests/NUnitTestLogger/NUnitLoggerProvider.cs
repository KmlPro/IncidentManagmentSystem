using System;
using Microsoft.Extensions.Logging;

//kbytner 18.10.2020 - inspiration https://github.com/MarshallMoorman/Extensions.Logging.NUnit
namespace IncidentReport.Infrastructure.ReadModels.IntegrationTests.NUnitTestLogger
{
    [ProviderAlias("NUnit")]
    public class NUnitLoggerProvider : ILoggerProvider
    {
        private readonly Func<string, LogLevel, bool> _filter;

        public NUnitLoggerProvider()
        {
            _filter = null;
        }
        public ILogger CreateLogger(string name)
        {
            return new NUnitLogger(name, _filter);
        }

        public void Dispose()
        {

        }
    }
}
