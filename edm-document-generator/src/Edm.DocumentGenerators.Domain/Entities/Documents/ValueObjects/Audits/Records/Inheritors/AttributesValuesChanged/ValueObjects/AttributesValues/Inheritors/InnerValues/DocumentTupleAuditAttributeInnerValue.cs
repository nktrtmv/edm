namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Audits.Records.Inheritors.AttributesValuesChanged.ValueObjects.AttributesValues.Inheritors.
    InnerValues;

public sealed class DocumentTupleAuditAttributeInnerValue
{
    public DocumentTupleAuditAttributeInnerValue(DocumentAuditAttributeValue[] innerValues)
    {
        InnerValues = innerValues;
    }

    public DocumentAuditAttributeValue[] InnerValues { get; }
}
