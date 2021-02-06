using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmashCombos.Controllers;
using SmashCombos.Core.Services;
using SmashCombos.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SmashCombos.Api.Tests.Integration
{
    public class TestStartup : Startup
    {
        public TestStartup(IConfiguration configuration) : base(configuration)
        {

        }

        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);

            services.AddMvc().AddApplicationPart(typeof(CharactersController).Assembly);

            SetUpInMemoryDbContext(services);
        }

        private void SetUpInMemoryDbContext(IServiceCollection services)
        {
            // Remove the app's PostgreSqlDatabaseContext registration.
            var descriptor = services.FirstOrDefault(d => d.ServiceType == typeof(IDbContext));

            if (descriptor != null)
            {
                services.Remove(descriptor);
            }
        }
    }
}
