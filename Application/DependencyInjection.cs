using Application.Services;
using Core.Interfaces;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Services
        services.AddScoped<StudentService>();
        services.AddScoped<RegistredUserService>();

        // Repositories
        services.AddScoped(typeof(IGenericRepoitory<>), typeof(GenericRepository<>));
        return services;
    }
}
