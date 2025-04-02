using Edm.DocumentGenerators.Application.Contracts.Attributes.Abstractions;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.AttributesValues.Inheritors.Dates;

public sealed class DocumentDateAttributeValueDetailedInternal
    : DocumentAttributeValueDetailedGenericInternal<UtcDateTime<DocumentDateAttributeValueDetailedInternal>>
{
    internal DocumentDateAttributeValueDetailedInternal(DocumentAttributeInternal attribute, UtcDateTime<DocumentDateAttributeValueDetailedInternal>[] values)
        : base(attribute, values)
    {
    }
}
