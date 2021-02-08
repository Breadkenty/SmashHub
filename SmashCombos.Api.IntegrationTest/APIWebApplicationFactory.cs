using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SmashCombos.Core.Services;
using SmashCombos.Persistence;
using System.IO;
using System.Linq;

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
                    .AddEntityFrameworkSqlite()
                    .BuildServiceProvider();

                // Add ApplicationDbContext using in-memory database for testing.
                services.AddDbContext<IDbContext, PostgreSqlDatabaseContext>(options =>
                {
                    var keepAliveConnection = new SqliteConnection("DataSource=InMemoryTestDb;mode=memory;cache=shared");
                    keepAliveConnection.Open();
                    options.UseSqlite(keepAliveConnection);
                    options.UseInternalServiceProvider(serviceProvider);
                });

                var sp = services.BuildServiceProvider();

                using(var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var db = scopedServices.GetRequiredService<IDbContext>();

                    db.Database.EnsureCreated();
                    db.Database.ExecuteSqlRaw(File.ReadAllText("seeds.sql"));
                    db.SaveChangesAsync(System.Threading.CancellationToken.None);
                }
            });
        }
    }
}
