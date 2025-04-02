using Edm.Document.Searcher.Application.Documents.Contracts.RegistryRoles;
using Edm.Document.Searcher.Application.Documents.Queries.Contracts.Filters;
using Edm.Document.Searcher.Application.Documents.Queries.Contracts.SortParameters;
using Edm.Document.Searcher.Domain.Documents.ValueObjects;
using Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments.Contracts.Contracts.Filters;
using Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments.Contracts.Contracts.SortParameters;
using Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments.Contracts.Queries.Get;

namespace Edm.Document.Searcher.Application.Documents.Queries.Get.Contracts;

internal static class GetDocumentsQueryInternalConverter
{
    internal static GetDocumentsQuery ToDomain(GetDocumentsQueryInternal query, SearchDocumentRegistryRoleInternal[] registryRoles)
    {
        DomainId domainId = DomainId.Parse(query.DomainId);

        SearchDocumentsQueryFilter[] filters =
            query.Filters.Select(SearchDocumentsQueryFilterInternalConverter.ToDomain).ToArray();

        SearchDocumentSortParameters sortParameters =
            SearchDocumentsQuerySortParametersInternalToDomainConverter.ToDomain(query.SortParameters, registryRoles);

        var result = new GetDocumentsQuery(domainId, filters, sortParameters, query.DocumentsIds, query.Limit, query.Skip);

        return result;
    }
}
