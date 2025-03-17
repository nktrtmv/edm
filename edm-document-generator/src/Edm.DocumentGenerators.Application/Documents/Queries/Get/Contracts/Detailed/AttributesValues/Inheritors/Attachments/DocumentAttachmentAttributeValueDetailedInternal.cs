using Edm.DocumentGenerators.Application.Contracts.Attributes.Abstractions;

namespace Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.AttributesValues.Inheritors.Attachments;

public sealed class DocumentAttachmentAttributeValueDetailedInternal : DocumentAttributeValueDetailedGenericInternal<string>
{
    internal DocumentAttachmentAttributeValueDetailedInternal(DocumentAttributeInternal attribute, string[] values)
        : base(attribute, values)
    {
    }
}
