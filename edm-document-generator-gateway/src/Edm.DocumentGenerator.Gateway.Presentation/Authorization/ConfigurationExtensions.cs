using System.Diagnostics.CodeAnalysis;

using Edm.DocumentGenerator.Gateway.GenericSubdomain.Swagger;

// ReSharper disable UnusedMethodReturnValue.Global
[assembly: ExcludeFromCodeCoverage]

namespace Edm.DocumentGenerator.Gateway.Presentation.Authorization;

public static class ConfigurationExtensions
{
    public static IServiceCollection AddKeycloak(this IServiceCollection services, IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(configuration);

        services.AddSingleton<AccessCheckerFacade>();

        return services;
    }

    public static IServiceCollection AddSwagger(this IServiceCollection services, IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(configuration);

        services.AddSwaggerGen(
            options =>
            {
                options.EnableAnnotations(true, true);

                SwaggerDerivedTypesConfiguration.ConfigureDerivedTypes(options);
            });

        return services;
    }
}
