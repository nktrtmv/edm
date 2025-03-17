using Edm.Entities.Approval.Rules.Gateway.Presentation.Configuration.Swagger;

namespace Edm.Entities.Approval.Rules.Gateway.Presentation.Configuration;

public static class ConfigurationExtensions
{
    public static IServiceCollection AddSwagger(this IServiceCollection services, IConfiguration configuration)
    {
        services.ConfigureSwaggerGen(
            options =>
            {
                SwaggerDerivedTypesConfiguration.ConfigureDerivedTypes(options);

                options.SchemaFilter<SwaggerConvertDiscriminatorsToEnumsSchemeFilter>();
            });

        return services;
    }
}
