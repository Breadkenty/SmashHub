using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Smash_Combos.Models;
using System.Diagnostics;
using System.Data.Common;
using System.Runtime.InteropServices;

namespace Smash_Combos
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();
            // var host = CreateWebHostBuilder(args).
            //               UseUrls("http://0.0.0.0:5000/;https://0.0.0.0:5001").
            //               Build();

            using (var scope = host.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
                var migrations = await context.Database.GetPendingMigrationsAsync();

                if (migrations.Count() > 0)
                {
                    Console.WriteLine("Starting to migrate database....");
                    try
                    {
                        await context.Database.MigrateAsync();
                        Console.WriteLine("Database is up to date, #party time");
                    }
                    catch (DbException)
                    {
                        Notify("Database Migration FAILED");
                        throw;
                    }
                }
            }

            var task = host.RunAsync();
            Notify("🚀");
            WebHostExtensions.WaitForShutdown(host);
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

        public static void Notify(string message)
        {
            var isWindows = System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
            var isMac = System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(OSPlatform.OSX);

            if (!isWindows && !isMac)
            {
                return;
            }

            // Create a process to launch the nodejs app `notifiy` with our message
            var process = isMac ? new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = ".bin/terminal-notifier.app/Contents/MacOS/terminal-notifier",
                    Arguments = $"-message \"{message}\" -title \"Smash_Combos\"",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                }
            } : new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = ".bin/snoretoast",
                    Arguments = $"-silent -m \"{message}\" -t \"Smash_Combos\"",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                }
            };

            // Start the message but do not wait for it to end, we don't care about the termination result.
            process.Start();
        }
    }
}
