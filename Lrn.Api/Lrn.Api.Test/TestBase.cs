using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

//https://docs.microsoft.com/pt-br/dotnet/architecture/microservices/multi-container-microservice-net-applications/test-aspnet-core-services-web-apps


namespace Lrn.Api.Test
{
    public class TestBase
    {
        private readonly TestServer _server;
        protected readonly HttpClient _client;
        protected string _controllerPath;
        public TestBase()
        {
            // Arrange
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        private bool IsStatusCode200(HttpStatusCode code) {
            return (code == HttpStatusCode.NoContent || code == HttpStatusCode.OK);
        }

        [Fact]
        public async Task TestGet()
        {
            if (string.IsNullOrEmpty(_controllerPath)){
                Assert.True(true);
                return;
            }

            // Act
            var response = await _client.GetAsync(_controllerPath + "/1");
            
            // Assert
            Assert.True(IsStatusCode200(response.StatusCode));
        }

        [Fact]
        public async Task TestList()
        {
            if (string.IsNullOrEmpty(_controllerPath)){
                Assert.True(true);
                return;
            }

            // Act
            var response = await _client.GetAsync(_controllerPath);

            // Assert
            Assert.True(IsStatusCode200(response.StatusCode));
        }
    }
}
