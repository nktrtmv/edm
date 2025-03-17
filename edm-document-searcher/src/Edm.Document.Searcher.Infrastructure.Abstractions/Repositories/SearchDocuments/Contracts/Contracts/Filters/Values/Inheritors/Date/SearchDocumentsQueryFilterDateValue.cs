using Edm.Document.Searcher.GenericSubdomain;
using Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments.Contracts.Contracts.Filters.Values.Abstrations;

namespace Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments.Contracts.Contracts.Filters.Values.Inheritors.Date;

public sealed class SearchDocumentsQueryFilterDateValue
    : SearchDocumentsQueryFilterValueGeneric<UtcDateTime<SearchDocumentsQueryFilter>>
{
    public SearchDocumentsQueryFilterDateValue(UtcDateTime<SearchDocumentsQueryFilter> value) : base(value)
    {
    }
}
