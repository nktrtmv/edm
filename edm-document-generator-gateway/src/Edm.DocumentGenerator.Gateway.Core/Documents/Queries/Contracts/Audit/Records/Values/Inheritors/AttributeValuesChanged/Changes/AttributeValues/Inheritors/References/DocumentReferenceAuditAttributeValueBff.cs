using Edm.DocumentGenerator.Gateway.Core.References.Values.Contracts;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.Audit.Records.Values.Inheritors.AttributeValuesChanged.Changes.AttributeValues.Inheritors.
    References;

public sealed class DocumentReferenceAuditAttributeValueBff : DocumentAuditAttributeValueBff
{
    public required ReferenceTypeValueBff[] Value { get; init; }
}
