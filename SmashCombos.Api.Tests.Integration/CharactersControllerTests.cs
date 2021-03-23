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
            var request = new HttpRequestMessage(HttpMethod.Get, "/characters");
            var response = await Client.SendAsync(request);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var json = await response.Content.ReadAsStringAsync();
            var characters = JsonConvert.DeserializeObject<IEnumerable<Core.Cqrs.Characters.GetCharacters.GetCharactersResponse>>(json);
            Assert.NotZero(characters.Count());
        }

        [TestCase("ink", ExpectedResult = 4)]
        [TestCase("mario", ExpectedResult = 2)]
        [TestCase("nonexistentcharacter", ExpectedResult = 0)]
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

            var login = await LoginAsync("testuseradmin@test.com", "testpassword");
            var putCharRequest = new Core.Cqrs.Characters.PutCharacter.PutCharacterRequest
            {
                CharacterId = characterToEdit.Id,
                CurrentUserId = login.User.Id,
                YPosition = characterToEdit.YPosition,
                ReleaseOrder = characterToEdit.ReleaseOrder,
                Name = editedName,
                VariableName = editedName
            };
            var response = await PutCharacterAsync(putCharRequest, login.Token);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var existingEditedCharacter = await GetCharacterAsync(editedName);
            Assert.NotNull(existingEditedCharacter);
            Assert.AreEqual(existingEditedCharacter.Name, editedName);
            Assert.AreEqual(existingEditedCharacter.VariableName, editedName);
        }
        [TestCase("Mario", "MarioEdited")]
        public async Task TryPutCharacterAsNonAdminAsync(string oldName, string editedName)
        {
            //Throw exception because GET method returns 404
            Assert.ThrowsAsync<HttpRequestException>(async () => await GetCharacterAsync(editedName));

            var characterToEdit = await GetCharacterAsync(oldName);
            Assert.NotNull(characterToEdit);

            var login = await LoginAsync("testuser@test.com", "testpassword");
            var putCharRequest = new Core.Cqrs.Characters.PutCharacter.PutCharacterRequest
            {
                CharacterId = characterToEdit.Id,
                CurrentUserId = login.User.Id,
                YPosition = characterToEdit.YPosition,
                ReleaseOrder = characterToEdit.ReleaseOrder,
                Name = editedName,
                VariableName = editedName
            };

            var response = await PutCharacterAsync(putCharRequest, login.Token);
            Assert.AreEqual(HttpStatusCode.Forbidden, response.StatusCode);

            //Throw exception because GET method returns 404
            Assert.ThrowsAsync<HttpRequestException>(async () => await GetCharacterAsync(editedName));

            var stillUneditedChar = await GetCharacterAsync(oldName);
            Assert.NotNull(stillUneditedChar);
        }

        [TestCase("New Character", "NewCharacter", 100, 50)]
        public async Task PostCharacterAsAdminAsync(string name, string variableName, int releaseOrder, int yPosition)
        {
            //Throw exception because GET method returns 404
            Assert.ThrowsAsync<HttpRequestException>(async () => await GetCharacterAsync(variableName));
            
            var login = await LoginAsync("testuseradmin@test.com", "testpassword");
            var postCharRequest = new Core.Cqrs.Characters.PostCharacter.PostCharacterRequest
            {
                CurrentUserId = login.User.Id,
                YPosition = yPosition,
                ReleaseOrder = releaseOrder,
                Name = name,
                VariableName = variableName
            };

            var response = await PostCharacterAsync(postCharRequest, login.Token);
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);

            var newlyAddedCharacter = await GetCharacterAsync(variableName);
            Assert.NotNull(newlyAddedCharacter);
        }
        [TestCase("New Character", "NewCharacter", 100, 50)]
        public async Task TryPostCharacterAsNonAdminAsync(string name, string variableName, int releaseOrder, int yPosition)
        {
            Assert.ThrowsAsync<HttpRequestException>(async () => await GetCharacterAsync(variableName));

            var login = await LoginAsync("testuser@test.com", "testpassword");

            var postCharRequest = new Core.Cqrs.Characters.PostCharacter.PostCharacterRequest
            {
                CurrentUserId = login.User.Id,
                YPosition = yPosition,
                ReleaseOrder = releaseOrder,
                Name = name,
                VariableName = variableName
            };

            var response = await PostCharacterAsync(postCharRequest, login.Token);
            
            Assert.AreEqual(HttpStatusCode.Forbidden, response.StatusCode);
            
            Assert.ThrowsAsync<HttpRequestException>(async () => await GetCharacterAsync(variableName));
        }

        [TestCase("Mario")]
        public async Task DeleteCharacterAsAdminAsync(string variableName)
        {
            var characterToDelete = await GetCharacterAsync($"{variableName}");
            Assert.NotNull(characterToDelete);

            var login = await LoginAsync("testuseradmin@test.com", "testpassword");
            var deleteCharRequest = new Core.Cqrs.Characters.DeleteCharacter.DeleteCharacterRequest
            {
                CharacterId = characterToDelete.Id,
                CurrentUserId = login.User.Id
            };

            var response = await DeleteCharacterAsync(deleteCharRequest, login.Token);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            //Throw exception because GET method returns 404
            Assert.ThrowsAsync<HttpRequestException>(async () => await GetCharacterAsync(variableName));
        }
        [TestCase("Mario")]
        public async Task TryDeleteCharacterAsNonAdminAsync(string variableName)
        {
            var characterToDelete = await GetCharacterAsync($"{variableName}");
            Assert.NotNull(characterToDelete);

            var login = await LoginAsync("testuser@test.com", "testpassword");
            var deleteCharRequest = new Core.Cqrs.Characters.DeleteCharacter.DeleteCharacterRequest
            {
                CharacterId = characterToDelete.Id,
                CurrentUserId = login.User.Id
            };

            var response = await DeleteCharacterAsync(deleteCharRequest, login.Token);

            Assert.AreEqual(HttpStatusCode.Forbidden, response.StatusCode);
            var stillExistingChar = await GetCharacterAsync($"{variableName}");
            Assert.NotNull(stillExistingChar);
        }

        private async Task<Core.Cqrs.Sessions.Login.LoginResponse> LoginAsync(string email, string password)
        {
            var loginRequest = new Core.Cqrs.Sessions.Login.LoginRequest
            {
                Email = email,
                Password = password
            };
            var jsonRequest = JsonConvert.SerializeObject(loginRequest);
            var request = new HttpRequestMessage(HttpMethod.Post, "/sessions")
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
            var request = new HttpRequestMessage(HttpMethod.Get, $"/characters/{variableName}");
            var response = await Client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            var json = await response.Content.ReadAsStringAsync();
            var character = JsonConvert.DeserializeObject<Core.Cqrs.Characters.GetCharacter.GetCharacterResponse>(json);
            return character;
        }

        private async Task<HttpResponseMessage> PostCharacterAsync(Core.Cqrs.Characters.PostCharacter.PostCharacterRequest postCharRequest, string authToken = null)
        {
            var jsonRequest = JsonConvert.SerializeObject(postCharRequest);
            var request = new HttpRequestMessage(HttpMethod.Post, $"/characters");
            request.Content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", authToken);
            var response = await Client.SendAsync(request);
            return response;
        }
        private async Task<HttpResponseMessage> PutCharacterAsync(Core.Cqrs.Characters.PutCharacter.PutCharacterRequest putCharRequest, string authToken = null) 
        {
            var jsonRequest = JsonConvert.SerializeObject(putCharRequest);
            var request = new HttpRequestMessage(HttpMethod.Put, $"/characters/{putCharRequest.VariableName}");
            request.Content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", authToken);
            var response = await Client.SendAsync(request);
            return response;
        }
        private async Task<HttpResponseMessage> DeleteCharacterAsync(Core.Cqrs.Characters.DeleteCharacter.DeleteCharacterRequest delCharRequest, string authToken = null)
        {
            var jsonRequest = JsonConvert.SerializeObject(delCharRequest);
            var request = new HttpRequestMessage(HttpMethod.Delete, $"/characters/{delCharRequest.CharacterId}");
            request.Content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", authToken);
            var response = await Client.SendAsync(request);
            return response;
        }
    }
}