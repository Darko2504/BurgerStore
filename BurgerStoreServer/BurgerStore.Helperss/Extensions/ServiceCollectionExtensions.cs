using BurgerStore.DataAcess.DbContext;
using BurgerStore.Domain.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BurgerStore.Helperss.Extensions
{
    public static class ServiceCollectionExtensions
    {

        public class ConfigBuilder
        {
            public IServiceCollection Services { get; set; }
            public IConfiguration Configuration { get; set; }
            public IdentityBuilder Identity { get; set; }
            public AuthenticationBuilder AuthenticationBuilder { get; set; }

            public ConfigBuilder(IServiceCollection services, IConfiguration configuration)
            {
                Services = services;
                Configuration = configuration;
            }
        }
        public static ConfigBuilder AddPostgreSqlDbContext(this IServiceCollection services, IConfigurationSection appSettings)
        {
            var connectionString = appSettings.GetValue<string>("ConnectionString");

            services.AddDbContext<BurgerAppDbContext>(options =>
                options.UseNpgsql(connectionString));

            // Return ConfigBuilder for chaining
            return new ConfigBuilder(services, appSettings.GetSection("").Value == null ? services.BuildServiceProvider().GetService<IConfiguration>() : null);
        }

        public static ConfigBuilder AddIdentityExtension(this ConfigBuilder builder)
        {
            builder.Services.AddIdentityCore<User>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
            })
            .AddEntityFrameworkStores<BurgerAppDbContext>()
            .AddDefaultTokenProviders();

            return builder;
        }

    }
}
