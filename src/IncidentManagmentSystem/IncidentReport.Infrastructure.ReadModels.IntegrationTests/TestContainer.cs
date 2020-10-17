using Autofac;
using IncidentReport.ReadModels.DIConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace IncidentReport.Infrastructure.ReadModels.IntegrationTests
{
    public class TestContainer
    {
        private IContainer _container;
        private static readonly ILoggerFactory _myLoggerFactory
            = LoggerFactory.Create(builder => { builder.AddConsole(); });

        public TestContainer()
        {
            var builder =  new ContainerBuilder();
            builder.RegisterModule(new ReadContextModule(optionsBuilder =>
            {
                optionsBuilder.UseInMemoryDatabase("Testname");
                optionsBuilder.UseLoggerFactory(_myLoggerFactory);
            }));

            this._container = builder.Build();
        }

        public ILifetimeScope BeginLifetimeScope()
        {
            return this._container.BeginLifetimeScope();
        }
    }
}
