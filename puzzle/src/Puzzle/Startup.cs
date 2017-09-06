using System;
using System.Diagnostics.Contracts;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Puzzle.Contexts;
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
			services.AddMvc().AddControllersAsServices();
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
        
        private IServiceCollection AddRepositories(IServiceCollection service)
        {
            service.AddDbContext<PuzzlerDbContext>(option =>
            {
                option.UseNpgsql(ContextFactory.BuildConnectionString());
            });
            service.AddScoped<PuzzleRepository>();
            return service;
        }
    }
}
