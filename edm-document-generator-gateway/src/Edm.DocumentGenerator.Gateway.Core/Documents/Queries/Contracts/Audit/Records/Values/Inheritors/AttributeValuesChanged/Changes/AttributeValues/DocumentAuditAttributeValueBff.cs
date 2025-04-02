using System.Text.Json.Serialization;

using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.Audit.Records.Values.Inheritors.AttributeValuesChanged.Changes.AttributeValues.Inheritors.
    Attachments;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.Audit.Records.Values.Inheritors.AttributeValuesChanged.Changes.AttributeValues.Inheritors.
    Booleans;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.Audit.Records.Values.Inheritors.AttributeValuesChanged.Changes.AttributeValues.Inheritors.Dates;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.Audit.Records.Values.Inheritors.AttributeValuesChanged.Changes.AttributeValues.Inheritors.
    Numbers;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.Audit.Records.Values.Inheritors.AttributeValuesChanged.Changes.AttributeValues.Inheritors.
    References;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.Audit.Records.Values.Inheritors.AttributeValuesChanged.Changes.AttributeValues.Inheritors.
    Strings;
using
    Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.Audit.Records.Values.Inheritors.AttributeValuesChanged.Changes.AttributeValues.Inheritors.Tuples;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.Audit.Records.Values.Inheritors.AttributeValuesChanged.Changes.AttributeValues;

[JsonDerivedType(typeof(DocumentAttachmentAuditAttributeValueBff), "Attachment")]
[JsonDerivedType(typeof(DocumentBooleanAuditAttributeValueBff), "Boolean")]
[JsonDerivedType(typeof(DocumentDateAuditAttributeValueBff), "Date")]
[JsonDerivedType(typeof(DocumentNumberAuditAttributeValueBff), "Number")]
[JsonDerivedType(typeof(DocumentReferenceAuditAttributeValueBff), "Reference")]
[JsonDerivedType(typeof(DocumentStringAuditAttributeValueBff), "String")]
[JsonDerivedType(typeof(DocumentTupleAuditAttributeValueBff), "Tuple")]
public abstract class DocumentAuditAttributeValueBff
{
    public required string AttributeId { get; init; }
    public required string FrontMetadata { get; init; }

    public override string ToString()
    {
        return $"AttributeId: {AttributeId}";
    }
}
