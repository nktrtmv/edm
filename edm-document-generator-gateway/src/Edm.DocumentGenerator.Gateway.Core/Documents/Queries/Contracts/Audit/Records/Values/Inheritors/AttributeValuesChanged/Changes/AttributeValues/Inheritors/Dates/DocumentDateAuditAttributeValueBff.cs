namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.Audit.Records.Values.Inheritors.AttributeValuesChanged.Changes.AttributeValues.Inheritors.
    Dates;

public sealed class DocumentDateAuditAttributeValueBff : DocumentAuditAttributeValueBff
{
    public required DateTime[] Value { get; init; }
}
