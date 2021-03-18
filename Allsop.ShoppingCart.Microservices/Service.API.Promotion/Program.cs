using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Service.API.Promotion
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureKestrel(options =>
                    {
                        options.ListenAnyIP(5004, listenOptions => 
                            listenOptions.Protocols = HttpProtocols.Http1);
                        // Setup a HTTP/2 endpoint without TLS.
                        options.ListenLocalhost(6004, o => o.Protocols = 
                            HttpProtocols.Http2);
                    });
                    webBuilder.UseStartup<Startup>();
                });
    }
}