using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

using Swashbuckle.AspNetCore.SwaggerGen;

namespace Edm.Entities.Approval.Rules.Gateway.Presentation.Configuration.Swagger;

internal sealed class SwaggerConvertDiscriminatorsToEnumsSchemeFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (schema.Discriminator is not null)
        {
            OpenApiSchema? discriminatorSchema = schema.Properties[schema.Discriminator.PropertyName];

            if (discriminatorSchema?.Type == "string")
            {
                ConvertDiscriminatorToEnum(schema, context);
            }
        }
    }

    private static void ConvertDiscriminatorToEnum(OpenApiSchema schema, SchemaFilterContext context)
    {
        List<IOpenApiAny> values = schema
            .Discriminator
            .Mapping
            .Select(x => new OpenApiString(x.Key))
            .Cast<IOpenApiAny>()
            .ToList();

        var enumSchema = new OpenApiSchema
        {
            Enum = values
        };

        OpenApiSchema? result = context.SchemaRepository.AddDefinition(
            context.Type.Name + "Type",
            enumSchema);

        schema.Properties[schema.Discriminator.PropertyName] = result;
    }
}
