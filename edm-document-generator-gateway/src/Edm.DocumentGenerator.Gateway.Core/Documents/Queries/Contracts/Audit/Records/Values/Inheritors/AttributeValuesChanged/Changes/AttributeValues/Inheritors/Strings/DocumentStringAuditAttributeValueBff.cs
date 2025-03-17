namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.Audit.Records.Values.Inheritors.AttributeValuesChanged.Changes.AttributeValues.Inheritors.
    Strings;

public sealed class DocumentStringAuditAttributeValueBff : DocumentAuditAttributeValueBff
{
    public required string[] Value { get; init; }
}
