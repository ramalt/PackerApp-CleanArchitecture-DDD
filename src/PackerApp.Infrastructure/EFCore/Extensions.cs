using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PackerApp.Infrastructure.EFCore.Contexts;
using PackerApp.Infrastructure.EFCore.Options;
using PackerApp.Shared.Options;

namespace PackerApp.Infrastructure.EFCore;

public static class Extensions
{
    public static void AddPostgreSql(this IServiceCollection services, IConfiguration configuration)
    {
        var options = configuration.GetOptions<PostgreSqlOptions>("PostgreSql");
        services.AddDbContext<ApplicationReadDbContext>(context => context.UseNpgsql(options.ConnectionString));
        services.AddDbContext<ApplicationWriteDbContext>(context => context.UseNpgsql(options.ConnectionString));

    }
}
