using Edm.DocumentGenerators.Application.Contracts.Attributes.Abstractions;

namespace Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.AttributesValues;

public abstract class DocumentAttributeValueDetailedInternal
{
    protected DocumentAttributeValueDetailedInternal(DocumentAttributeInternal attribute)
    {
        Attribute = attribute;
    }

    public DocumentAttributeInternal Attribute { get; }
}
