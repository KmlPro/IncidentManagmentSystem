using Autofac.Extensions.DependencyInjection;
using IncidentManagementSystem.Web.JustForTests;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;

namespace IncidentManagmentSystem.ApiBehavioursTests.IncidentReport
{
    public static class TestWebHostBuilderFactory
    {
        public static IHostBuilder Create()
        {
            var hostBuilder = new HostBuilder()
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHost(webHost =>
                {
                    webHost.UseTestServer();
                    webHost.UseStartup<TestStartup>();
                });

            return hostBuilder;
        }
    }
}
