using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using PackerApp.Domain.Factoires;
using PackerApp.Domain.Policies;
using PackerApp.Shared;

namespace PackerApp.Application;

public static class Extensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddCommands();
        services.AddSingleton<IPackingListFactory, PackingListFactory>();

        // Auto IoC registration with Scrutor package from service assemblies. Exmple: Gender Policies, Temprature Policies etc.
        services.Scan(s => s.FromAssemblies(Assembly.GetCallingAssembly())
                            .AddClasses(c => c.AssignableTo(typeof(IPackingItemPolicy)))
                            .AsImplementedInterfaces()
                            .WithScopedLifetime());
    }
}
