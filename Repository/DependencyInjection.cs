using Microsoft.Extensions.DependencyInjection;
using Repository.Repositories.Interfaces;
using Repository.Repositories;

namespace Repository
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepositoryLayer(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IEducationRepository, EducationRepository>();
            services.AddScoped<ISettingRepository, SettingRepository>();
            services.AddScoped<IGroupRepository, GroupRepository>();
            return services;
        }
    }
}
