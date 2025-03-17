namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.Audit.Records.Values.Inheritors.AttributeValuesChanged.Changes.AttributeValues.Inheritors.
    Booleans;

public sealed class DocumentBooleanAuditAttributeValueBff : DocumentAuditAttributeValueBff
{
    public required bool[] Value { get; init; }
}
