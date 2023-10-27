using Microsoft.Extensions.DependencyInjection;
using PackerApp.Shared;

namespace PackerApp.Infrastructure;

public static class Extensions
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddQueries();
    }
}
