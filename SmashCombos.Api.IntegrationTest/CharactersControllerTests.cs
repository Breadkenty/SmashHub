using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace SmashCombos.Api.Tests.Integration
{
    public class CharactersControllerTests
    {
        private HttpClient _client;
        private APIWebApplicationFactory<Startup> _factory;

        [SetUp]
        public void Setup()
        {
            _factory = new APIWebApplicationFactory<Startup>();
            _client = _factory.CreateClient();
        }

        [TearDown]
        public void TearDown()
        {
            _client.Dispose();
            _factory.Dispose();
        }

        [Test]
        public async Task CharactersGetAllAsync()
        {
            var request = new HttpRequestMessage(new HttpMethod("GET"), "/characters");
            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var json = await response.Content.ReadAsStringAsync();
            var characters = JsonConvert.DeserializeObject<IEnumerable<Core.Cqrs.Characters.GetCharacters.GetCharactersResponse>>(json);
            Assert.NotZero(characters.Count());
        }
    }
}