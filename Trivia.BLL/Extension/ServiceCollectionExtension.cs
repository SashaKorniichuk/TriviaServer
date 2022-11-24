using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Trivia.DAL;
using Trivia.DAL.Repositories.Abstractions;
using Trivia.DAL.Repositories;

namespace Trivia.BLL.Extension
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection RegisterDbContext(this IServiceCollection services, Action<DbContextOptionsBuilder> optionsActions)
        {
            services.AddDbContext<DataContext>(optionsActions);
            return services;
        }
        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(EFGenericRepository<>));
            return services;
        }
        public static IServiceCollection RegisterAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            return services;
        }
    }
}
