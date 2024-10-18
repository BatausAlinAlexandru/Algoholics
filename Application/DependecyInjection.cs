using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // aici adaugati dependentele pe care le folositi


            return services;
        }
    }
}
