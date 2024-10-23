using Domain.Aggregates.UserAggregate.Repositories;
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
                options.UseSqlServer("Server=172.28.144.1, 1433;Database=AlgoholicsDB;User Id=sa;Password=ParolaComplexa123!; TrustServerCertificate=true;"));

            services.AddTransient<IUserAccountRepository, UserAccountRepository>();

            return services;
        }
    }
}
