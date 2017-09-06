using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Puzzle.Repositories;

namespace Puzzle
{
    public class Startup
    {
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

        public IContainer ApplicationContainer { get; private set; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public IServiceProvider ConfigureServices(IServiceCollection services)
		{
			services.AddMvc();
            var builder = new ContainerBuilder();
            AddRepositories(services);
            builder.Populate(services);
            ApplicationContainer = builder.Build();
            return new AutofacServiceProvider(ApplicationContainer);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseMvc();
		}
        //public Startup(IHostingEnvironment env)
        //{
        //    var builder = new ConfigurationBuilder()
        //        .SetBasePath(env.ContentRootPath)
        //        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        //        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
        //        .AddEnvironmentVariables();
        //    Configuration = builder.Build();
        //}

        //public IContainer ApplicationContainer { get; private set; }

        //public IConfigurationRoot Configuration { get; }

        //// This method gets called by the runtime. Use this method to add services to the container.
        //public void ConfigureServices(IServiceCollection services)
        //{
        //    // Add framework services.
        //    services.AddMvc();
        //    var builder = new ContainerBuilder();
        //    //AddRepositories(services);
        //    builder.Populate(services);
        //    ApplicationContainer = builder.Build();
        //}
        
        private IServiceCollection AddRepositories(IServiceCollection service)
        {
           service.AddScoped<PuzzleRepository>();
           return service;
        }

        //// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //public void Configure(IApplicationBuilder app,
        //                      IHostingEnvironment env,
        //                      ILoggerFactory loggerFactory,
        //                      IApplicationLifetime appLifetime)
        //{

        //    app.UseMvc();
        //    appLifetime.ApplicationStopped.Register(() => this.ApplicationContainer.Dispose());
        //}
    }
}
