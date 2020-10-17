using System.Net.Http;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;

namespace IncidentManagementSystem.ApiBehavioursTests.WebAppTestConfiguration
{
    public static class TestClientFactory
    {
        public static HttpClient GetHttpClient()
        {
            var hostBuilder = TestWebHostBuilderFactory.Create(false);

            var host = hostBuilder.StartAsync().Result;

            return host.GetTestClient();
        }

        public static HttpClient GetHttpClientProductionStartup()
        {
            var hostBuilder = TestWebHostBuilderFactory.Create(true);

            var host = hostBuilder.StartAsync().Result;

            return host.GetTestClient();
        }
    }
}
