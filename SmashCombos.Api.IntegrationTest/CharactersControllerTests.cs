using Newtonsoft.Json;
using NUnit.Framework;
using SmashCombos.Core.Services;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace SmashCombos.Api.Tests.Integration
{
    public class CharactersControllerTests : ControllerTests
    {
        [Test]
        public async Task CharactersGetAllAsync()
        {
            var request = new HttpRequestMessage(new HttpMethod("GET"), "/characters");
            var response = await Client.SendAsync(request);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var json = await response.Content.ReadAsStringAsync();
            var characters = JsonConvert.DeserializeObject<IEnumerable<Core.Cqrs.Characters.GetCharacters.GetCharactersResponse>>(json);
            Assert.NotZero(characters.Count());
        }

        [TestCase("link", ExpectedResult = 3)]
        [TestCase("mario", ExpectedResult = 2)]
        public async Task<int> CharactersGetAllFilterAsync(string filter)
        {
            var request = new HttpRequestMessage(new HttpMethod("GET"), $"/characters?filter={filter}");
            var response = await Client.SendAsync(request);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var json = await response.Content.ReadAsStringAsync();
            var characters = JsonConvert.DeserializeObject<IEnumerable<Core.Cqrs.Characters.GetCharacters.GetCharactersResponse>>(json);
            return characters.Count();
        }

        [TestCase("Peach")]
        public async Task CharacterByVariableNameAsync(string variableName)
        {
            var request = new HttpRequestMessage(new HttpMethod("GET"), $"/characters/{variableName}");
            var response = await Client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var json = await response.Content.ReadAsStringAsync();
            var character = JsonConvert.DeserializeObject<Core.Cqrs.Characters.GetCharacter.GetCharacterResponse>(json);
            Assert.NotNull(character);
        }
    }
}