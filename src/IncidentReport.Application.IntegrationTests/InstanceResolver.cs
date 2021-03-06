using Autofac;
using IncidentReport.Infrastructure.DIContainer;

namespace IncidentReport.Application.IntegrationTests
{
    public class InstanceResolver
    {
        public static T Resolve<T>() where T: class
        {
            return CompositionRoot.BeginLifetimeScope().Resolve<T>();
        }
    }
}
