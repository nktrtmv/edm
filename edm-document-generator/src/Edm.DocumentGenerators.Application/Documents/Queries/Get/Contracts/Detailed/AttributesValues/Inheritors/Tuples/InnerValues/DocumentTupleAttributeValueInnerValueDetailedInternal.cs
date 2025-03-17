namespace Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.AttributesValues.Inheritors.Tuples.InnerValues;

public sealed class DocumentTupleAttributeValueInnerValueDetailedInternal
{
    public DocumentTupleAttributeValueInnerValueDetailedInternal(DocumentAttributeValueDetailedInternal[] innerValues)
    {
        InnerValues = innerValues;
    }

    public DocumentAttributeValueDetailedInternal[] InnerValues { get; }
}
