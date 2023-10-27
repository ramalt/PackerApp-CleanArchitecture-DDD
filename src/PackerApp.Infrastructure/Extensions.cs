using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PackerApp.Application.Services;
using PackerApp.Domain.Repositories;
using PackerApp.Infrastructure.EFCore;
using PackerApp.Infrastructure.Repositories;
using PackerApp.Infrastructure.Services;
using PackerApp.Shared;

namespace PackerApp.Infrastructure;

public static class Extensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddPostgreSql(configuration);
        services.AddScoped<IPackingListRepository, PackingListRepository>();
        services.AddScoped<IPackingListReadService, PackingListReadService>();
        services.AddSingleton<IWeatherService, DumbWeatherService>();
        services.AddQueries();
    }
}
