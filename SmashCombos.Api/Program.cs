using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;

namespace SmashCombos
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();
            _ = host.RunAsync();
            Console.WriteLine("🚀");
            WebHostExtensions.WaitForShutdown(host);
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            var builder = WebHost.CreateDefaultBuilder(args);
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
            {
                builder = builder.UseUrls("http://0.0.0.0:5000/;https://0.0.0.0:5001");
            }
            return builder.UseStartup<Startup>();
        }
    }
}
