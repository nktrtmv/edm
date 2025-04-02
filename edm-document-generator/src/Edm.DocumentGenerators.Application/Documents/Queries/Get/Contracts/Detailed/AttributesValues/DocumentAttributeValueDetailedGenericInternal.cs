using Edm.DocumentGenerators.Application.Contracts.Attributes.Abstractions;

namespace Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.AttributesValues;

public abstract class DocumentAttributeValueDetailedGenericInternal<T> : DocumentAttributeValueDetailedInternal
{
    protected DocumentAttributeValueDetailedGenericInternal(DocumentAttributeInternal attribute, T[] values) : base(attribute)
    {
        Values = values;
    }

    public T[] Values { get; private set; }
}
