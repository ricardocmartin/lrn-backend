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
            Assert.NotNull(response.EnsureSuccessStatusCode());
            //Assert.True(IsStatusCode200(response.StatusCode));
            //Assert.Equal("text/html; charset=utf-8", response.Content.Headers.ContentType.ToString());
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
            Assert.NotNull(response.EnsureSuccessStatusCode());
        }
    }
}
