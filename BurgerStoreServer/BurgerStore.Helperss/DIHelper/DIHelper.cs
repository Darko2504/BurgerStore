using BurgerStore.DataAcess.Abstractions;
using BurgerStore.DataAcess.Implementations;
using BurgerStore.Services.Abstractions;
using BurgerStore.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace BurgerStore.Helperss.DIHelper
{
    public static class DIHelper
    {
        public static void InjectDbRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBurgerRepository, BurgerRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
        }

        public static void InjectServices(this IServiceCollection services)
        {
            services.AddScoped<IBurgerService, BurgerService>();
            services.AddScoped<IOrderService, OrderService>();
        }
    }
}
