using System;
using System.Collections;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Puzzle.Contexts
{
    public class ContextFactory : IDesignTimeDbContextFactory<PuzzlerDbContext>
	{

        public PuzzlerDbContext CreateDbContext(string[] args)
        {
		   IConfigurationRoot configuration = new ConfigurationBuilder()
    		   .SetBasePath(Directory.GetCurrentDirectory())
    		   .AddJsonFile("appsettings.json")
    		   .Build();

            var builder = new DbContextOptionsBuilder<PuzzlerDbContext>();

            builder.UseNpgsql(BuildConnectionString());

            return new PuzzlerDbContext(builder.Options);
        }

		private string BuildConnectionString()
		{
			IDictionary dict = Environment.GetEnvironmentVariables();
			var dbUser = dict["POSTGRES_USER"];
			var dbPassword = dict["POSTGRES_PASSWORD"];
			var networkUrl = dict["NETWORK_URL"];
			var dbName = dict["POSTGRES_DB"];
			return $"Host={networkUrl};Database={dbName};Pooling=true;" +
				$"User ID={dbUser};Password={dbPassword};";
		}
    }
}
