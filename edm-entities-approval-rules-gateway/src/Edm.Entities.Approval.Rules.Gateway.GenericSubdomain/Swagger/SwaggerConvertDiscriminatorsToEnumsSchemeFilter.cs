using System.Reflection;

using Edm.Entities.Approval.Rules.Gateway.GenericSubdomain.Swagger.Attributes;

using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

using Swashbuckle.AspNetCore.SwaggerGen;

namespace Edm.Entities.Approval.Rules.Gateway.GenericSubdomain.Swagger;

internal sealed class SwaggerConvertDiscriminatorsToEnumsSchemeFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (schema.Discriminator is not null)
        {
            OpenApiSchema discriminatorSchema;

            if (context.Type.GetCustomAttribute<DiscriminatorTypeAttributeAbstract>() is { } attribute)
            {
                if (!context.SchemaRepository.TryLookupByType(attribute.GetDiscriminatorType(), out discriminatorSchema))
                {
                    discriminatorSchema = context.SchemaGenerator.GenerateSchema(attribute.GetDiscriminatorType(), context.SchemaRepository);
                }
            }
            else
            {
                discriminatorSchema = CreateEnumForDiscriminator(schema, context);
            }

            schema.Properties[schema.Discriminator.PropertyName] = discriminatorSchema;
        }
    }

    private static OpenApiSchema CreateEnumForDiscriminator(OpenApiSchema schema, SchemaFilterContext context)
    {
        List<string> discriminatorKeys = schema
            .Discriminator
            .Mapping
            .Select(x => x.Key)
            .ToList();

        const string none = "None";

        if (!discriminatorKeys.Contains(none))
        {
            discriminatorKeys.Insert(0, none);
        }

        IEnumerable<OpenApiString> values =
            discriminatorKeys.Select(x => new OpenApiString(x));

        var enumSchema = new OpenApiSchema
        {
            Enum = new List<IOpenApiAny>(values)
        };

        var result = context.SchemaRepository.AddDefinition(
            context.Type.Name + "Type",
            enumSchema);

        return result;
    }
}
