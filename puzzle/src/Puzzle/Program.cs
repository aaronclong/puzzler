using System;
using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Puzzle
{
    public class Program
    {

		public static void Main(string[] args)
		{
			BuildWebHost(args).Run();
		}

		public static IWebHost BuildWebHost(string[] args) =>
			WebHost.CreateDefaultBuilder(args)
				   .ConfigureAppConfiguration((builderContext, config) => {
            config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        })
                   .UseStartup<Startup>()
                   .Build();
    }
}
