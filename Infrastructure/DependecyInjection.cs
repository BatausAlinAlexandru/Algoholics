using Domain.Aggregates.CategoryAggregate.Repositories;
using Domain.Aggregates.OrderAggregate.Repositories;
using Domain.Aggregates.ProductAggregate.Repositories;
using Domain.Aggregates.UserAggregate.Repositories;
using Domain.Aggregates.WishListAggregate.Repository;
using Domain.Aggregates.CartAggregate.Repository;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer("Server=localhost;Database=AlgoholicsDB;Integrated Security=True;TrustServerCertificate=True;"));

            services.AddTransient<IUserAccountRepository, UserAccountRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ISubcategoryRepository, SubcategoryRepository>();
            services.AddTransient<IFilterGroupRepository, FilterGroupRepository>();
            services.AddTransient<IFilterValueRepository, FilterValueRepository>();
            services.AddTransient<IWishListRepository, WishListRepository>();
            services.AddTransient<ICartRepository, CartRepository>();



            return services;
        }
    }
}
