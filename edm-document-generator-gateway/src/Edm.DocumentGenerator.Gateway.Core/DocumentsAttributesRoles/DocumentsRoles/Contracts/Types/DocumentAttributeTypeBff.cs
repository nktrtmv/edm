using System.Text.Json.Serialization;

using Edm.DocumentGenerator.Gateway.Core.Contracts.Attributes.Types;
using Edm.DocumentGenerator.Gateway.Core.DocumentsAttributesRoles.DocumentsRoles.Contracts.Types.Inheritors;
using Edm.DocumentGenerator.Gateway.GenericSubdomain.Swagger.Attributes;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentsAttributesRoles.DocumentsRoles.Contracts.Types;

[DiscriminatorType<DocumentAttributeBffType>]
[JsonDerivedType(typeof(DocumentAttachmentAttributeTypeBff), nameof(DocumentAttributeBffType.Attachment))]
[JsonDerivedType(typeof(DocumentBooleanAttributeTypeBff), nameof(DocumentAttributeBffType.Boolean))]
[JsonDerivedType(typeof(DocumentDateAttributeTypeBff), nameof(DocumentAttributeBffType.Date))]
[JsonDerivedType(typeof(DocumentNumberAttributeTypeBff), nameof(DocumentAttributeBffType.Number))]
[JsonDerivedType(typeof(DocumentReferenceAttributeTypeBff), nameof(DocumentAttributeBffType.Reference))]
[JsonDerivedType(typeof(DocumentStringAttributeTypeBff), nameof(DocumentAttributeBffType.String))]
[JsonDerivedType(typeof(DocumentTupleAttributeTypeBff), nameof(DocumentAttributeBffType.Tuple))]
public abstract class DocumentAttributeTypeBff
{
}
