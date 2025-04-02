using Microsoft.Extensions.DependencyInjection;

using Edm.DocumentGenerator.Gateway.Core.Validators;
using Edm.DocumentGenerator.Gateway.Core.Validators.Enrichers;

// ReSharper disable UnusedMethodReturnValue.Global
// ReSharper disable UnusedMethodReturnValue.Local

namespace Edm.DocumentGenerator.Gateway.Core.Extensions;

public static class CoreExtensions
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        services.AddAllTypesFromAssemblies<IDocumentValidatorEnricher>(ServiceLifetime.Singleton);
        services.AddAllTypesFromAssemblies<IDocumentValidator>(ServiceLifetime.Singleton);

        return services;
    }

    private static IServiceCollection AddAllTypesFromAssemblies<TAssignable>(this IServiceCollection services, ServiceLifetime lifetime)
    {
        var assignable = typeof(TAssignable);
        List<Type> types = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(x => x.GetTypes())
            .Where(x => !x.IsAbstract && x.IsAssignableTo(assignable))
            .ToList();

        foreach (var foundType in types)
        {
            services.Add(new ServiceDescriptor(assignable, foundType, lifetime));
        }

        return services;
    }
}
