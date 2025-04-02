using Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments.Contracts.Contracts.Filters.Values.Abstrations;

namespace Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments.Contracts.Contracts.Filters.Values.Inheritors.String;

public sealed class SearchDocumentsQueryFilterStringValue
    : SearchDocumentsQueryFilterValueGeneric<string>
{
    public SearchDocumentsQueryFilterStringValue(string value) : base(value)
    {
    }
}
