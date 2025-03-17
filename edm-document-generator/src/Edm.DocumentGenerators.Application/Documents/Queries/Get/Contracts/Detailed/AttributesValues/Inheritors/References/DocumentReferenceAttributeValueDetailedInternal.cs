using Edm.DocumentGenerators.Application.Contracts.Attributes.Abstractions;

namespace Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.AttributesValues.Inheritors.References;

public sealed class DocumentReferenceAttributeValueDetailedInternal : DocumentAttributeValueDetailedGenericInternal<string>
{
    internal DocumentReferenceAttributeValueDetailedInternal(DocumentAttributeInternal attribute, string[] values)
        : base(attribute, values)
    {
    }
}
