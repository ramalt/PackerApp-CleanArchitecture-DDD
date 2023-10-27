using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PackerApp.Infrastructure.EFCore;
using PackerApp.Infrastructure.EFCore.Options;
using PackerApp.Shared;
using PackerApp.Shared.Options;

namespace PackerApp.Infrastructure;

public static class Extensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddPostgreSql(configuration);
        services.AddQueries();
    }
}
