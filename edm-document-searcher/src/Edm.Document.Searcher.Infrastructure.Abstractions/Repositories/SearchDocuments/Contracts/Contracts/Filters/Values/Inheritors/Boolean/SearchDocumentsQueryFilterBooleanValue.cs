using Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments.Contracts.Contracts.Filters.Values.Abstrations;

namespace Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments.Contracts.Contracts.Filters.Values.Inheritors.Boolean;

public sealed class SearchDocumentsQueryFilterBooleanValue
    : SearchDocumentsQueryFilterValueGeneric<bool>
{
    public SearchDocumentsQueryFilterBooleanValue(bool value) : base(value)
    {
    }
}
