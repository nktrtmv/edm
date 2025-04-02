using Edm.Document.Searcher.Domain.Documents.ValueObjects.AttributesValues.Abstractions;
using Edm.Document.Searcher.GenericSubdomain;

namespace Edm.Document.Searcher.Domain.Documents.ValueObjects.AttributesValues.Inheritors.Numbers;

public sealed class SearchDocumentNumberAttributeValue : SearchDocumentAttributeValueGeneric<Number<SearchDocumentNumberAttributeValue>>
{
    public SearchDocumentNumberAttributeValue(int registryRoleId, Number<SearchDocumentNumberAttributeValue>[] values)
        : base(registryRoleId, values)
    {
    }
}
