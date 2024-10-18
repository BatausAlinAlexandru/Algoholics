using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependecyInjection 
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            // aici adaugati dependentele pe care le folositi


            return services;
        }
    }
}
