using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace SmashCombos.Api.Tests.Integration
{
    public class ControllerTests
    {
        private APIWebApplicationFactory<TestStartup> _factory;
        protected HttpClient Client;

        [SetUp]
        public void Setup()
        {
            _factory = new APIWebApplicationFactory<TestStartup>();
            Client = _factory.CreateClient();
        }

        [TearDown]
        public void TearDown()
        {
            Client.Dispose();
            _factory.Dispose();
        }
    }
}
