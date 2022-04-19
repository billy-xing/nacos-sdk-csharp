namespace WebApiCore21
{
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Nacos.V2.DependencyInjection;

    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();

            /*
            var builder = CreateWebHostBuilder(args);

            builder.Configuration
                .AddEnvironmentVariables();


            builder.Services.AddNacosV2Config(builder.Configuration.GetSection("NacosConfig"));

            builder.Configuration.AddNacosV2Configuration(builder.Configuration.GetSection("NacosConfig"));

            builder.Services.AddControllers();

            var app = builder.Build();
            app.MapControllers();

            app.Run();
            */
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(builder =>
                {
                    builder.AddNacosV2Configuration(builder.Build().GetSection("NacosConfig"));
                })
                .UseStartup<Startup>();
    }
}
