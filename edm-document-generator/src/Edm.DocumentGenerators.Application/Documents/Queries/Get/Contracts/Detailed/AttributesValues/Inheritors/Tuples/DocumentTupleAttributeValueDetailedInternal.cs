using Edm.DocumentGenerators.Application.Contracts.Attributes.Abstractions;
using Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.AttributesValues.Inheritors.Tuples.InnerValues;

namespace Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.AttributesValues.Inheritors.Tuples;

public sealed class DocumentTupleAttributeValueDetailedInternal : DocumentAttributeValueDetailedGenericInternal<DocumentTupleAttributeValueInnerValueDetailedInternal>
{
    internal DocumentTupleAttributeValueDetailedInternal(DocumentAttributeInternal attribute, DocumentTupleAttributeValueInnerValueDetailedInternal[] values)
        : base(attribute, values)
    {
    }
}
