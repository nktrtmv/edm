using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.Audit.Records.Values.Inheritors.AttributeValuesChanged.Changes.AttributeValues.Inheritors.Tuples
    .InnerValues;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.Audit.Records.Values.Inheritors.AttributeValuesChanged.Changes.AttributeValues.Inheritors.
    Tuples;

public sealed class DocumentTupleAuditAttributeValueBff : DocumentAuditAttributeValueBff
{
    public required DocumentTupleAuditAttributeValueInnerValueBff[] Value { get; init; }
}
