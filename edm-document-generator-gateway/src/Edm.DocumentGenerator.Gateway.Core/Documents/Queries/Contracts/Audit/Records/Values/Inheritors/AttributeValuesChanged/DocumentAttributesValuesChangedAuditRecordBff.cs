using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.Audit.Records.Values.Inheritors.AttributeValuesChanged.Changes;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.Audit.Records.Values.Inheritors.AttributeValuesChanged;

public sealed class DocumentAttributesValuesChangedAuditRecordBff : DocumentAuditRecordValueBff
{
    public required DocumentAttributesValuesChangedAuditRecordChangeBff[] Change { get; init; }
}
