using Edm.DocumentGenerators.Application.Contracts.Attributes.Abstractions;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.AttributesValues.Inheritors.Numbers;

public sealed class DocumentNumberAttributeValueDetailedInternal
    : DocumentAttributeValueDetailedGenericInternal<Number<DocumentNumberAttributeValueDetailedInternal>>
{
    internal DocumentNumberAttributeValueDetailedInternal(DocumentAttributeInternal attribute, Number<DocumentNumberAttributeValueDetailedInternal>[] values)
        : base(attribute, values)
    {
    }
}
