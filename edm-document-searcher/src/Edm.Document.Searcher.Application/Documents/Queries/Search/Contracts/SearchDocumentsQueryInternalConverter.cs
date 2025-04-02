using Edm.Document.Searcher.Application.Documents.Contracts.RegistryRoles;
using Edm.Document.Searcher.Application.Documents.Queries.Contracts.Filters;
using Edm.Document.Searcher.Application.Documents.Queries.Contracts.SortParameters;
using Edm.Document.Searcher.Domain.Documents.ValueObjects;
using Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments.Contracts.Contracts.Filters;
using Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments.Contracts.Contracts.SortParameters;
using Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments.Contracts.Queries.Search;

namespace Edm.Document.Searcher.Application.Documents.Queries.Search.Contracts;

internal static class SearchDocumentsQueryInternalConverter
{
    internal static SearchDocumentsQuery ToDomain(SearchDocumentsQueryInternal query, SearchDocumentRegistryRoleInternal[] registryRoles)
    {
        DomainId domainId = DomainId.Parse(query.DomainId);

        SearchDocumentsQueryFilter[] filters =
            query.Filters.Select(SearchDocumentsQueryFilterInternalConverter.ToDomain).ToArray();

        SearchDocumentSortParameters sortParameters =
            SearchDocumentsQuerySortParametersInternalToDomainConverter.ToDomain(query.SortParameters, registryRoles);

        var result = new SearchDocumentsQuery(domainId, filters, sortParameters, query.Limit, query.Skip);

        return result;
    }
}
