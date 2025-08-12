using Microsoft.Extensions.DependencyInjection;
using Service.Services;
using Service.Services.Interfaces;

namespace Service
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServiceLayer(this IServiceCollection services)
        {
            services.AddScoped<IEducationService, EducationService>();
            services.AddScoped<ISettingService, SettingService>();
            services.AddScoped<IGroupService, GroupService>();
            services.AddScoped<IAccountService, AccountService>();
            return services;
        }
    }
}
