using Edm.DocumentGenerators.Application.Contracts.Attributes.Abstractions;

namespace Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.AttributesValues.Inheritors.Strings;

public sealed class DocumentStringAttributeValueDetailedInternal : DocumentAttributeValueDetailedGenericInternal<string>
{
    internal DocumentStringAttributeValueDetailedInternal(DocumentAttributeInternal attribute, string[] values)
        : base(attribute, values)
    {
    }
}
