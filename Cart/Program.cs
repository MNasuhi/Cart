using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Data.Helpers;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Cart
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            CreateDbIfNotExist(host);
            
            host.Run();
        }

        private static void CreateDbIfNotExist(IWebHost host)
        {
            using (var scope = host.Services.CreateScope() )
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<MyDbContext>();
                    DbInitializer.Initialize(context);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    throw;
                }

            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
