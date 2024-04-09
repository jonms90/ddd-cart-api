using System.Net;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc.Testing;

namespace DDDCart.API.IntegrationTests
{
    public class BasicTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public BasicTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Get_CartGivesUnauthorized()
        {
            var response = await _factory.CreateClient().GetAsync("/cart");
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Fact]
        public async Task Get_IdentityAccessTokenReturnsOK()
        {
            var client = _factory.CreateClient();

            var tokenResponse = await client.PostAsync("/identity/accesstoken", new StringContent(""));
            var accessToken = await tokenResponse.Content.ReadAsStringAsync();
            var response = await client.SendAsync(new HttpRequestMessage(HttpMethod.Get, "/cart")
            {
                Headers = { Authorization = new AuthenticationHeaderValue("Bearer", accessToken) }
            });

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}