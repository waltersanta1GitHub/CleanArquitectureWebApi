using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<SchoolDbContext>(options =>

        options.UseSqlServer( configuration.GetConnectionString("DefaultConection"))

        );

        services.AddScoped(typeof(IGenericRepoitory<>), typeof(GenericRepository<>));
        return services;
    
    }

}
