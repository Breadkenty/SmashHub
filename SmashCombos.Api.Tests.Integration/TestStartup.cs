using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmashCombos.Controllers;
using SmashCombos.Core.Services;
using SmashCombos.Persistence;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SmashCombos.Api.Tests.Integration
{
    public class TestStartup : Startup
    {
        public TestStartup(IConfiguration configuration) : base(configuration)
        {
            configuration["JWT_KEY"] = "TESTKEY_ABCDEFGHIJKLMNOPQRSTUVWWXYZ";
        }

        public override void SetUpDataBase(IServiceCollection services)
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder
            {
                DataSource = ":memory:"
            };
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SqliteConnection(connectionString);
            services.AddDbContext<IDbContext, PostgreSqlDatabaseContext>(
                options => options.UseSqlite(connection)
            );
        }

        public override void EnsureDatabaseCreated(IDbContext dbContext)
        {
            dbContext.Database.OpenConnection();
            dbContext.Database.EnsureCreated();
            dbContext.Database.ExecuteSqlRaw(File.ReadAllText("seeds.sql"));
            dbContext.SaveChangesAsync(System.Threading.CancellationToken.None).Wait();
        }
    }
}
