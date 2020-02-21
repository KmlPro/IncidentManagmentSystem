using System.Net.Http;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;

namespace IncidentManagmentSystem.Web.Tests
{
    [TestFixture]
    public class BaseTest
    {
        protected HttpClient TestClient { get; private set; }

        [OneTimeSetUp]
        public void Setup()
        {
            var hostBuilder = new HostBuilder()
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHost(webHost =>
                {
                    webHost.UseTestServer();
                    webHost.UseStartup<Startup>();
                });

            var host = hostBuilder.StartAsync().Result;

            this.TestClient = host.GetTestClient();
        }
    }
}
