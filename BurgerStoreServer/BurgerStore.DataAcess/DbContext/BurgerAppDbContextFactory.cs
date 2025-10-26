using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace BurgerStore.DataAcess.DbContext
{
    public class BurgerAppDbContextFactory : IDesignTimeDbContextFactory<BurgerAppDbContext>
    {
        public BurgerAppDbContext CreateDbContext(string[] args)
        {
            // path to your main project where appsettings.json exists
            var config = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../BurgerStore"))
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var connectionString = config.GetSection("AppSettings:ConnectionString").Value;

            var optionsBuilder = new DbContextOptionsBuilder<BurgerAppDbContext>();
            optionsBuilder.UseNpgsql(connectionString);

            return new BurgerAppDbContext(optionsBuilder.Options);
        }
    }
}
