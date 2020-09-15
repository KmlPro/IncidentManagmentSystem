using Autofac.Extensions.DependencyInjection;
using IncidentManagementSystem.Web;
using IncidentManagementSystem.Web.Configuration.JustForTests;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;

namespace IncidentManagementSystem.ApiBehavioursTests.IncidentReport
{
    public static class TestWebHostBuilderFactory
    {
        public static IHostBuilder Create(bool productionStartup)
        {
            var hostBuilder = new HostBuilder()
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHost(webHost =>
                {
                    webHost.UseTestServer();
                    SetStartup(webHost, productionStartup);
                });

            return hostBuilder;
        }

        private static void SetStartup(IWebHostBuilder webHost, bool productionStartup)
        {
            if (productionStartup)
            {
                webHost.UseStartup<Startup>();
            }
            else
            {
                webHost.UseStartup<TestStartup>();
            }
        }
    }
}
