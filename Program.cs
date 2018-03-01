using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace AspNetCoreTest
{
    class Program
    {
        static void Main(string[] args)
        {
          var config = new ConfigurationBuilder()
            .AddCommandLine(args)
            .Build();
          var host = new WebHostBuilder()
            .UseKestrel()
            .UseStartup<Startup>()
            .UseConfiguration(config)
            .Build();
          host.Run();

        }
    }

  internal class Startup
  {
    public Startup(IHostingEnvironment env)
    {
    }
    public void Configure(IApplicationBuilder app,
      IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
      app.Run(async (context) =>
      {
        await context.Response.WriteAsync("Hello, world!");
      });
    }

  }
}
