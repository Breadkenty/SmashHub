using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SmashCombos.Core.Services;
using SmashCombos.Persistence;
using Microsoft.EntityFrameworkCore;
using SmashCombos.Domain.Models;

namespace SmashCombos.Api.Tests.Integration
{
    public class APIWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services => {

                // Remove the app's PostgreSqlDatabaseContext registration.
                var descriptor = services.FirstOrDefault(d => d.ServiceType == typeof(IDbContext));

                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }

                var serviceProvider = new ServiceCollection()
                    .AddEntityFrameworkInMemoryDatabase()
                    .BuildServiceProvider();

                // Add ApplicationDbContext using an in-memory database for testing.
                services.AddDbContext<IDbContext, PostgreSqlDatabaseContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryTestDb");
                    options.UseInternalServiceProvider(serviceProvider);
                });

                var sp = services.BuildServiceProvider();

                using(var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var db = scopedServices.GetRequiredService<IDbContext>();

                    db.Database.EnsureCreated();

                    //TODO: Seed the in-memory db here. (Probably use an sql file)
                    db.Characters.Add(new Character { Name = "Mario", ReleaseOrder = 1, VariableName = "Mario", YPosition = 30, Combos = new List<Combo>() });
                    db.SaveChangesAsync(System.Threading.CancellationToken.None);
                }
            });
        }
    }
}
