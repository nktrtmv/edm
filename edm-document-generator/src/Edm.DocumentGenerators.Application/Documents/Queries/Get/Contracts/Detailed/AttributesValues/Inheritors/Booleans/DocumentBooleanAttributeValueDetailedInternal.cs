using Edm.DocumentGenerators.Application.Contracts.Attributes.Abstractions;

namespace Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.AttributesValues.Inheritors.Booleans;

public sealed class DocumentBooleanAttributeValueDetailedInternal : DocumentAttributeValueDetailedGenericInternal<bool>
{
    internal DocumentBooleanAttributeValueDetailedInternal(DocumentAttributeInternal attribute, bool[] values)
        : base(attribute, values)
    {
    }
}
