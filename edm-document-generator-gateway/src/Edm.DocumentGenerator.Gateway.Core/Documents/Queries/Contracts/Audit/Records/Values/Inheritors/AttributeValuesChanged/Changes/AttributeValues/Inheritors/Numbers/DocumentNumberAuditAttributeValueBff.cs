namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.Audit.Records.Values.Inheritors.AttributeValuesChanged.Changes.AttributeValues.Inheritors.
    Numbers;

public sealed class DocumentNumberAuditAttributeValueBff : DocumentAuditAttributeValueBff
{
    public required long[] Value { get; init; }
}
