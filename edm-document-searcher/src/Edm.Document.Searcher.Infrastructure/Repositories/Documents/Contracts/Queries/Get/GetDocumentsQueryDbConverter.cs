using Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments.Contracts.Queries.Get;
using Edm.Document.Searcher.Infrastructure.Repositories.Documents.Contracts.Queries.Converters.Filters;
using Edm.Document.Searcher.Infrastructure.Repositories.Documents.Contracts.Queries.Converters.SortParameters;

namespace Edm.Document.Searcher.Infrastructure.Repositories.Documents.Contracts.Queries.Get;

internal static class GetDocumentsQueryDbConverter
{
    internal static GetDocumentsQueryDb FromDomain(GetDocumentsQuery query)
    {
        string filters = SearchDocumentsQueryFiltersDbConverter.FromDomain(query.Filters);

        string sortParameters = SearchDocumentSortParametersDbConverter.FromDomain(query.SortParameters);

        var result = new GetDocumentsQueryDb(query.DomainId.Value, filters, sortParameters, query.DocumentsIds, query.Limit, query.Skip);

        return result;
    }
}
