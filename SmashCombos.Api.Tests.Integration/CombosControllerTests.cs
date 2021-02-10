using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SmashCombos.Api.Tests.Integration
{
    public class CombosControllerTests : ControllerTests
    {
        [Test]
        public async Task CombosGetAllAsync()
        {
            var request = new HttpRequestMessage(new HttpMethod("GET"), "/combos");
            var response = await Client.SendAsync(request);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var json = await response.Content.ReadAsStringAsync();
            var combos = JsonConvert.DeserializeObject<IEnumerable<Core.Cqrs.Combos.GetCombos.GetCombosResponse>>(json);
            Assert.NotZero(combos.Count());
        }

        [TestCase(1)]
        public async Task CombosGetOneAsync(int comboId)
        {
            var request = new HttpRequestMessage(new HttpMethod("GET"), $"/combos/{comboId}");
            var response = await Client.SendAsync(request);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var json = await response.Content.ReadAsStringAsync();
            var combo = JsonConvert.DeserializeObject<Core.Cqrs.Combos.GetCombo.GetComboResponse>(json);
            Assert.NotNull(combo);
        }
    }
}
