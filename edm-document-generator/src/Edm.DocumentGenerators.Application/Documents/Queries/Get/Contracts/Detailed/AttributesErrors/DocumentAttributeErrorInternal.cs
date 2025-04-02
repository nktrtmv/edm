using Edm.DocumentGenerators.Application.Contracts.Attributes.Abstractions;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.AttributesErrors;

public sealed class DocumentAttributeErrorInternal
{
    public DocumentAttributeErrorInternal(Id<DocumentAttributeInternal> attributeId, string message)
    {
        AttributeId = attributeId;
        Message = message;
    }

    public Id<DocumentAttributeInternal> AttributeId { get; }
    public string Message { get; }
}
