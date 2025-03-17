using Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments.Contracts.Contracts.Filters.Values.Abstrations;

namespace Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments.Contracts.Contracts.Filters.Values.Inheritors.Reference;

public sealed class SearchDocumentsQueryFilterReferenceValue
    : SearchDocumentsQueryFilterValueGeneric<string>
{
    public SearchDocumentsQueryFilterReferenceValue(string value) : base(value)
    {
    }
}
