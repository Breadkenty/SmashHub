using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SmashCombos.Api.Tests.Integration
{
    public class SessionsControllerTests : ControllerTests
    {
        [TestCase("testuser0@test.com", "testpassword", "TestUser0", Domain.Models.UserType.Admin)]
        [TestCase("testuser1@test.com", "testpassword", "TestUser1", Domain.Models.UserType.Moderator)]
        [TestCase("testuser2@test.com", "testpassword", "TestUser2", Domain.Models.UserType.User)]
        public async Task UsersLoginSuccessAsync(string email, string password, string displayName, Domain.Models.UserType type)
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
            Assert.NotNull(responseObject.User);
            Assert.AreEqual(responseObject.User.Email, email);
            Assert.AreEqual(responseObject.User.DisplayName, displayName);
            Assert.AreEqual(responseObject.User.UserType, type);
            Assert.NotNull(responseObject.Token);
        }
    }
}
