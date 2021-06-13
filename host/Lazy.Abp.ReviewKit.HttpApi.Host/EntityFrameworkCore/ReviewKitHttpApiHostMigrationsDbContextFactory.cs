using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Lazy.Abp.ReviewKit.EntityFrameworkCore
{
    public class ReviewKitHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<ReviewKitHttpApiHostMigrationsDbContext>
    {
        public ReviewKitHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<ReviewKitHttpApiHostMigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("ReviewKit"));

            return new ReviewKitHttpApiHostMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
