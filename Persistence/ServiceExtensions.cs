using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;

namespace Persistence;

public static class ServiceExtensions
{
    public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BancosDbContext>(option => 
            option.UseSqlServer(
            configuration.GetConnectionString("DefaultConnection"),
            b => b.MigrationsAssembly(typeof(BancosDbContext).Assembly.FullName)
        ));

        #region Repositories

        services.AddTransient(typeof(IRepositoryAsync<>), typeof(AppRepositoryAsync<>));

        #endregion
    }
}