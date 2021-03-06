﻿using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace SFA.Catalog.API
{
    public class Program
    {
        public static Task Main(string[] args)
        {
            return CreateHostBuilder(args).Build().RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
                webBuilder.CaptureStartupErrors(true);
                webBuilder.UseSetting(WebHostDefaults.DetailedErrorsKey, "true");
            })
            .ConfigureHostConfiguration(configHost =>
            {
                configHost.SetBasePath(Directory.GetCurrentDirectory());
                configHost.AddJsonFile("hostsettings.json", optional: true);
                configHost.AddJsonFile("appsettings.json", optional: true);
                configHost.AddEnvironmentVariables(prefix: "SFA_");
                configHost.AddCommandLine(args);
            });
    }
}
