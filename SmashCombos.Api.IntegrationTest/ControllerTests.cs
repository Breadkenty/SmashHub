using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace SmashCombos.Api.Tests.Integration
{
    public class ControllerTests
    {
        private APIWebApplicationFactory<Startup> _factory;
        protected HttpClient Client;

        [OneTimeSetUp]
        public void Setup()
        {
            _factory = new APIWebApplicationFactory<Startup>();
            Client = _factory.CreateClient();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            Client.Dispose();
            _factory.CloseDbConnection();
            _factory.Dispose();
        }
    }
}
