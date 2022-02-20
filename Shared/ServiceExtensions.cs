using Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Services;

namespace Shared;

public static class ServiceExtensions
{
    public static void AddShareInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IDatetimeService, DatetimeService>();
    }
}