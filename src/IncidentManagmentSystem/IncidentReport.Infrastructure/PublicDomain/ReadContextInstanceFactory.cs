using Autofac;
using IncidentReport.Infrastructure.Configuration.DIContainer;

namespace IncidentReport.Infrastructure.PublicDomain
{
    public static class ReadContextInstanceFactory
    {
        public static IReadIncidentReportDbContext Get()
        {
            using (var scope = CompositionRoot.BeginLifetimeScope())
            {
                var readContext = scope.Resolve<IReadIncidentReportDbContext>();

                return readContext;
            }
        }
    }
}
