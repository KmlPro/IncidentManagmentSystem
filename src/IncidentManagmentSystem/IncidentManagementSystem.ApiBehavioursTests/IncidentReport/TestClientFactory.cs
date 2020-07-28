using System.Net.Http;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;

namespace IncidentManagementSystem.ApiBehavioursTests.IncidentReport
{
    public static class TestClientFactory
    {
        public static HttpClient GetHttpClient()
        {
            var hostBuilder = TestWebHostBuilderFactory.Create();

            var host = hostBuilder.StartAsync().Result;

            return host.GetTestClient();
        }
    }
}
