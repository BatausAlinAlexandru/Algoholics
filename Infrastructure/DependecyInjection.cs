using Domain.Aggregates.UserAggregate.Repositories;
using Domain.Aggregates.OrderAggregate.Repositories;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Domain.Aggregates.ProductAggregate.Repositories;
using Domain.Aggregates.WishlistAggregate.Repositories;

namespace Application
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer("Server=localhost;Database=AlgoholicsDB;Integrated Security=True;TrustServerCertificate=True;"));

            services.AddTransient<IUserAccountRepository, UserAccountRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IWishlistRepository, WishlistRepository>();

            return services;
        }
    }
}
