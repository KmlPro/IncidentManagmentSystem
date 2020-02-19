using System.Net.Http;
using Autofac.Extensions.DependencyInjection;
using IncidentManagmentSystem.Web.Tests.Mocks.JsonMoq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
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
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                Converters = new[] { new JsonMockConverter() }
            };

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

        protected string CreateRequestBody(object obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.Indented,
                new JsonSerializerSettings
                {
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects
                });
        }
    }
}
