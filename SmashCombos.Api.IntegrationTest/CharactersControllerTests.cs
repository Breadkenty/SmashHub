using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using NUnit.Framework;
using SmashCombos.Core.Services;
using SmashCombos.Domain.Models;
using System.Collections.Generic;
using System.Data.Common;
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

        [OneTimeSetUp]
        public void Setup()
        {
            _factory = new APIWebApplicationFactory<Startup>();
            _client = _factory.CreateClient();
        }

        [OneTimeTearDown]
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