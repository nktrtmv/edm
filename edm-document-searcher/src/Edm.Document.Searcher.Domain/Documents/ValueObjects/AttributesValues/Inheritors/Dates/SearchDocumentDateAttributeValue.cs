using Edm.Document.Searcher.Domain.Documents.ValueObjects.AttributesValues.Abstractions;
using Edm.Document.Searcher.GenericSubdomain;

namespace Edm.Document.Searcher.Domain.Documents.ValueObjects.AttributesValues.Inheritors.Dates;

public sealed class SearchDocumentDateAttributeValue : SearchDocumentAttributeValueGeneric<UtcDateTime<SearchDocumentDateAttributeValue>>
{
    public SearchDocumentDateAttributeValue(int registryRoleId, params UtcDateTime<SearchDocumentDateAttributeValue>[] values) :
        base(registryRoleId, values)
    {
    }
}
