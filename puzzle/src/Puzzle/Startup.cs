using Autofac;
using Autofac.Extensions.DependencyInjection;
using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Puzzle.Contexts;

namespace Puzzle
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IContainer ApplicationContainer { get; private set; }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();
            var connectionString = BuildConnectionString();
            services.AddDbContext<PuzzlerDbContext>(option => option.UseNpgsql(connectionString));
            var builder = new ContainerBuilder();
            builder.Populate(services);
            ApplicationContainer = builder.Build();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
                              IHostingEnvironment env,
                              ILoggerFactory loggerFactory,
                              IApplicationLifetime appLifetime)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();
            appLifetime.ApplicationStopped.Register(() => this.ApplicationContainer.Dispose());
        }

        private string BuildConnectionString()
        {
            var dict = Environment.GetEnvironmentVariables();
            var dbUser = dict["POSTGRES_USER"];
            var dbPassword = dict["POSTGRES_PASSWORD"];
            var networkUrl = dict["NETWORK_URL"];
            var dbName = dict["POSTGRES_DB"];
            return $"User ID={dbUser};Password={dbPassword};" +
                   $"Host={networkUrl};Port=5432;Database={dbName};Pooling=true;";
        }
    }
}
