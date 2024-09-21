namespace PostsDAL_EF.Context;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

public class PostsContextFactory : IDesignTimeDbContextFactory<PostsContext>
{
    public PostsContext CreateDbContext(string[] args)
    {
        // Build the configuration
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory()) // Ensure you are in the correct folder
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        // Get the connection string
        var connectionString = configuration.GetConnectionString("PgsqlConnection");

        var optionsBuilder = new DbContextOptionsBuilder<PostsContext>();
        optionsBuilder.UseNpgsql(connectionString);

        return new PostsContext(optionsBuilder.Options);
    }
}