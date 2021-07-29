using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;

namespace DbMigrator
{
    public class DbContextFactory : IDesignTimeDbContextFactory<StripeDbContext>
    {
        public StripeDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<StripeDbContext>();
            var configuration = BuildConfiguration();
            optionsBuilder.UseNpgsql(configuration["ConnectionString"],
                ob => ob.MigrationsAssembly(nameof(DbMigrator)));
            return new StripeDbContext(optionsBuilder.Options, default);
        }

        public static IConfiguration BuildConfiguration()
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            if (environment == null)
                throw new Exception("Application environment is not set");
            var builder = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json", false)
                .AddJsonFile($"appsettings.{environment}.json", true, true);
            return builder.Build();
        }
    }
}
