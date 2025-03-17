using System.Text.Json.Serialization;

using Edm.DocumentGenerator.Gateway.Core.Contracts.DocumentStatus.Parameters.Inheritors.Booleans;
using Edm.DocumentGenerator.Gateway.Core.Contracts.DocumentStatus.Parameters.Inheritors.DocumentStatuses;
using Edm.DocumentGenerator.Gateway.Core.Contracts.DocumentStatus.Parameters.Inheritors.ReferenceAttributes;
using Edm.DocumentGenerator.Gateway.Core.Contracts.DocumentStatus.Parameters.Inheritors.Strings;
using Edm.DocumentGenerator.Gateway.Core.Contracts.DocumentStatus.Parameters.Types;
using Edm.DocumentGenerator.Gateway.GenericSubdomain.Swagger.Attributes;

namespace Edm.DocumentGenerator.Gateway.Core.Contracts.DocumentStatus.Parameters;

[DiscriminatorType<DocumentStatusParameterBffType>]
[JsonDerivedType(typeof(BooleanDocumentStatusParameterBff), nameof(DocumentStatusParameterBffType.Boolean))]
[JsonDerivedType(typeof(StringDocumentStatusParameterBff), nameof(DocumentStatusParameterBffType.String))]
[JsonDerivedType(typeof(ReferenceAttributeDocumentStatusParameterBff), nameof(DocumentStatusParameterBffType.ReferenceAttribute))]
[JsonDerivedType(typeof(DocumentStatusDocumentStatusParameterBff), nameof(DocumentStatusParameterBffType.DocumentStatus))]
public abstract class DocumentStatusParameterBff
{
    public required string Kind { get; init; }
    public string? DisplayName { get; set; }
    public string? Description { get; set; }
    public string? Group { get; set; }
}
