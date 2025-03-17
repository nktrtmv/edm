using System.Text.Json.Serialization;

using Edm.DocumentGenerator.Gateway.Core.Contracts.Attributes;
using Edm.DocumentGenerator.Gateway.Core.Contracts.Permissions.Types;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.AttributesValues.Inheritors.Attachments;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.AttributesValues.Inheritors.Booleans;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.AttributesValues.Inheritors.Dates;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.AttributesValues.Inheritors.Numbers;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.AttributesValues.Inheritors.References;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.AttributesValues.Inheritors.Strings;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.AttributesValues.Inheritors.Tuples;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.AttributesValues;

[JsonDerivedType(typeof(DocumentAttachmentAttributeValueDetailedBff), "Attachment")]
[JsonDerivedType(typeof(DocumentBooleanAttributeValueDetailedBff), "Boolean")]
[JsonDerivedType(typeof(DocumentDateAttributeValueDetailedBff), "Date")]
[JsonDerivedType(typeof(DocumentNumberAttributeValueDetailedBff), "Number")]
[JsonDerivedType(typeof(DocumentReferenceAttributeValueDetailedBff), "Reference")]
[JsonDerivedType(typeof(DocumentStringAttributeValueDetailedBff), "String")]
[JsonDerivedType(typeof(DocumentTupleAttributeValueDetailedBff), "Tuple")]
public abstract class DocumentAttributeValueDetailedBff
{
    public required DocumentAttributeBff Attribute { get; init; }

    public DocumentPermissionTypeBff[] Permissions { get; set; } = Array.Empty<DocumentPermissionTypeBff>();
}
