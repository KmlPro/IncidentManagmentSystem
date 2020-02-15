using System.Net.Http;
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
        private TestServer _testServer;
        protected HttpClient TestClient { get; private set; }

        [OneTimeSetUp]
        public void Setup()
        {
            var builder = new WebHostBuilder()
                .UseEnvironment(Environments.Development)
                .UseStartup<Startup>();

            this._testServer = new TestServer(builder);
            this.TestClient = this._testServer.CreateClient();
        }

        protected string CreateRequestBody(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
