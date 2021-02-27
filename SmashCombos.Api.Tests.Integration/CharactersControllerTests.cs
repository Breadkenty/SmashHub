using Newtonsoft.Json;
using NUnit.Framework;
using SmashCombos.Core.Services;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SmashCombos.Api.Tests.Integration
{
    public class CharactersControllerTests : ControllerTests
    {
        [Test]
        public async Task GetAllCharactersAsync()
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
        public async Task<int> GetAllCharactersFilterAsync(string filter)
        {
            var request = new HttpRequestMessage(new HttpMethod("GET"), $"/characters?filter={filter}");
            var response = await Client.SendAsync(request);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var json = await response.Content.ReadAsStringAsync();
            var characters = JsonConvert.DeserializeObject<IEnumerable<Core.Cqrs.Characters.GetCharacters.GetCharactersResponse>>(json);
            return characters.Count();
        }

        [TestCase("Peach")]
        public async Task GetCharacterByVariableNameAsync(string variableName)
        {
            var character = await GetCharacterAsync(variableName);
            Assert.NotNull(character);
        }

        [TestCase("Mario", "MarioEdited")]
        public async Task PutCharacterAsAdminAsync(string oldName, string editedName)
        {
            //Throw exception because GET method returns 404
            Assert.ThrowsAsync<HttpRequestException>(async () => await GetCharacterAsync(editedName));

            var characterToEdit = await GetCharacterAsync(oldName);
            Assert.NotNull(characterToEdit);

            var login = await LoginAsync("testuser0@test.com", "testpassword");
            var putCharRequest = new Core.Cqrs.Characters.PutCharacter.PutCharacterRequest
            {
                CharacterId = characterToEdit.Id,
                CurrentUserId = login.User.Id,
                YPosition = characterToEdit.YPosition,
                ReleaseOrder = characterToEdit.ReleaseOrder,
                Name = editedName,
                VariableName = editedName
            };
            var jsonRequest = JsonConvert.SerializeObject(putCharRequest);

            var request = new HttpRequestMessage(new HttpMethod("PUT"), $"/characters/{editedName}");
            request.Content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", login.Token);
            var response = await Client.SendAsync(request);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var existingEditedCharacter = await GetCharacterAsync(editedName);
            Assert.NotNull(existingEditedCharacter);
            Assert.AreEqual(existingEditedCharacter.Name, editedName);
            Assert.AreEqual(existingEditedCharacter.VariableName, editedName);
        }

        [TestCase("New Character", "NewCharacter", 100, 50)]
        public async Task PostCharacterAsAdminAsync(string name, string variableName, int releaseOrder, int yPosition)
        {
            //Throw exception because GET method returns 404
            Assert.ThrowsAsync<HttpRequestException>(async () => await GetCharacterAsync(variableName));
            
            var login = await LoginAsync("testuser0@test.com", "testpassword");

            var postCharRequest = new Core.Cqrs.Characters.PostCharacter.PostCharacterRequest
            {
                CurrentUserId = login.User.Id,
                YPosition = yPosition,
                ReleaseOrder = releaseOrder,
                Name = name,
                VariableName = variableName
            };

            var jsonRequest = JsonConvert.SerializeObject(postCharRequest);
            var request = new HttpRequestMessage(new HttpMethod("POST"), $"/characters");
            request.Content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", login.Token);
            var response = await Client.SendAsync(request);
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);

            var newlyAddedCharacter = await GetCharacterAsync(variableName);
            Assert.NotNull(newlyAddedCharacter);
        }

        [TestCase("Mario")]
        public async Task DeleteCharacterAsAdminAsync(string variableName)
        {
            var characterToDelete = await GetCharacterAsync($"{variableName}");
            Assert.NotNull(characterToDelete);

            var login = await LoginAsync("testuser0@test.com", "testpassword");
            var deleteCharRequest = new Core.Cqrs.Characters.DeleteCharacter.DeleteCharacterRequest
            {
                CharacterId = characterToDelete.Id,
                CurrentUserId = login.User.Id
            };
            var jsonRequest = JsonConvert.SerializeObject(deleteCharRequest);

            var request = new HttpRequestMessage(new HttpMethod("DELETE"), $"/characters/{characterToDelete.Id}");
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", login.Token);
            var response = await Client.SendAsync(request);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            //Throw exception because GET method returns 404
            Assert.ThrowsAsync<HttpRequestException>(async () => await GetCharacterAsync(variableName));
        }

        private async Task<Core.Cqrs.Sessions.Login.LoginResponse> LoginAsync(string email, string password)
        {
            var loginRequest = new Core.Cqrs.Sessions.Login.LoginRequest
            {
                Email = email,
                Password = password
            };
            var jsonRequest = JsonConvert.SerializeObject(loginRequest);
            var request = new HttpRequestMessage(new HttpMethod("POST"), "/sessions")
            {
                Content = new StringContent(jsonRequest, Encoding.UTF8, "application/json")
            };

            var response = await Client.SendAsync(request);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var responseObject = JsonConvert.DeserializeObject<Core.Cqrs.Sessions.Login.LoginResponse>(jsonResponse);
            return responseObject;
        }

        private async Task<Core.Cqrs.Characters.GetCharacter.GetCharacterResponse> GetCharacterAsync(string variableName)
        {
            var request = new HttpRequestMessage(new HttpMethod("GET"), $"/characters/{variableName}");
            var response = await Client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            var json = await response.Content.ReadAsStringAsync();
            var character = JsonConvert.DeserializeObject<Core.Cqrs.Characters.GetCharacter.GetCharacterResponse>(json);
            return character;
        }
    }
}