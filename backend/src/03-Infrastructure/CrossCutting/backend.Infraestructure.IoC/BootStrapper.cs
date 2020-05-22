using backend.Application.Services;
using backend.Domain.Repositories;
using backend.Domain.Services;
using backend.Infraestructure.Data.EF.Context;
using backend.Infraestructure.Data.EF.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace backend.Infraestructure.IoC
{
    public static class BootStrapper
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            // Repositories
            services.AddScoped<UserContext>();
            services.AddScoped<IUserRepository, UserRepository>();

            // Services
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}