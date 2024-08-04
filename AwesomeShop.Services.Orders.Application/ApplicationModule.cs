using AwesomeShop.Services.Orders.Application.Queries.GetOrderById;
using Microsoft.Extensions.DependencyInjection;

namespace AwesomeShop.Services.Orders.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(GetOrderByIdQuery).Assembly));

            return services;
        }
    }
}
