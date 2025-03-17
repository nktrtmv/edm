using Edm.Document.Searcher.GenericSubdomain;
using Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments.Contracts.Contracts.Filters.Values.Abstrations;

namespace Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments.Contracts.Contracts.Filters.Values.Inheritors.Number;

public sealed class SearchDocumentsQueryFilterNumberValue
    : SearchDocumentsQueryFilterValueGeneric<Number<SearchDocumentsQueryFilter>>
{
    public SearchDocumentsQueryFilterNumberValue(Number<SearchDocumentsQueryFilter> value) : base(value)
    {
    }
}
