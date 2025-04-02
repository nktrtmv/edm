using Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Abstractions.Attributes;

namespace Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Abstractions;

public abstract class DocumentAttributeValueExternalGeneric<T>(DocumentAttributeExternal attribute, T[] values)
    : DocumentAttributeValueExternal(attribute)
{
    public T[] Values { get; } = values;
}
