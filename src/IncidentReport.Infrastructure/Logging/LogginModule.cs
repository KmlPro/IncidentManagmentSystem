using Autofac;
using Serilog;

namespace IncidentReport.Infrastructure.Logging
{
    internal class LoggingModule : Module
    {
        private readonly ILogger _logger;

        internal LoggingModule(ILogger logger)
        {
            this._logger = logger;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(this._logger)
                .As<ILogger>()
                .SingleInstance();
        }
    }
}
