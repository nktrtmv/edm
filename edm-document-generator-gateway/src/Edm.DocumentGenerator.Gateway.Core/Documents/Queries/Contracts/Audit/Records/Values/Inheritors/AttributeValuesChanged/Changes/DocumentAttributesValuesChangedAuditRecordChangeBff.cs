using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.Audit.Records.Values.Inheritors.AttributeValuesChanged.Changes.AttributeValues;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.Audit.Records.Values.Inheritors.AttributeValuesChanged.Changes;

public sealed class DocumentAttributesValuesChangedAuditRecordChangeBff
{
    public required DocumentAuditAttributeValueBff From { get; init; }
    public required DocumentAuditAttributeValueBff To { get; init; }
}
