using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using PackerApp.Shared.Abstractions.Commands;
using PackerApp.Shared.Abstractions.Queries;
using PackerApp.Shared.Commands;
using PackerApp.Shared.Queries;

namespace PackerApp.Shared;

public static class Extensions
{
    public static void AddCommands(this IServiceCollection services)
    {
        services.AddSingleton<ICommandDispatcher, InMemoryCommandDiscpatcher>();

        // Auto IoC Container registration with Scrutor package from service assemblies
        services.Scan(s => s.FromAssemblies(Assembly.GetCallingAssembly())
                            .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>)))
                            .AsImplementedInterfaces()
                            .WithScopedLifetime());
    }

        public static void AddQueries(this IServiceCollection services)
    {
        services.AddSingleton<IQueryDispatcher, InMemoryQueryDispatcher>();

        // Auto IoC Container registration with Scrutor package from service assemblies
        services.Scan(s => s.FromAssemblies(Assembly.GetCallingAssembly())
                            .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>)))
                            .AsImplementedInterfaces()
                            .WithScopedLifetime());
    }
}
