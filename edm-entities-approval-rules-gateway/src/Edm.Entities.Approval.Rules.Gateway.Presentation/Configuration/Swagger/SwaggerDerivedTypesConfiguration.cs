using System.Reflection;
using System.Text.Json.Serialization;

using Swashbuckle.AspNetCore.SwaggerGen;

namespace Edm.Entities.Approval.Rules.Gateway.Presentation.Configuration.Swagger;

internal static class SwaggerDerivedTypesConfiguration
{
    public static void ConfigureDerivedTypes(SwaggerGenOptions options)
    {
        options.UseOneOfForPolymorphism();

        options.SelectSubTypesUsing(
            subtype => subtype
                .GetCustomAttributes<JsonDerivedTypeAttribute>()
                .Select(attribute => attribute.DerivedType));

        options.SelectDiscriminatorNameUsing(_ => "$type");

        options.SelectDiscriminatorValueUsing(GetDiscriminatorValue);

        options.SchemaFilter<SwaggerConvertDiscriminatorsToEnumsSchemeFilter>();
    }

    private static string GetDiscriminatorValue(Type subType)
    {
        for (var type = subType; type.BaseType is not null; type = type.BaseType)
        {
            var attribute = type.BaseType
                .GetCustomAttributes<JsonDerivedTypeAttribute>()
                .FirstOrDefault(x => x.DerivedType == subType);

            if (attribute?.TypeDiscriminator is string result)
            {
                return result;
            }
        }

        throw new InvalidOperationException($"Cannot determine value for subtype {subType}");
    }
}
