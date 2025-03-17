using Edm.Document.Searcher.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Documents;
using Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.Contracts.Filters;
using Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.Contracts.SortParameters;

namespace Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.GetAll.Contracts;

internal static class GetAllDocumentsQueryBffConverter
{
    internal static GetDocumentsQuery ToDto(
        GetAllDocumentsQueryBff query,
        int skip,
        int limit,
        DomainRoles domainRoles)
    {
        var filters =
            query.Filters.Select(x => SearchDocumentsQueryFilterBffConverter.ToDto(x, domainRoles)).ToArray();

        var sortParameters =
            SearchDocumentsQuerySortParametersBffConverter.ToDto(query.SortParameters, domainRoles);

        var result = new GetDocumentsQuery
        {
            DomainId = query.DomainId,
            Filters = { filters },
            SortParameters = sortParameters,
            Limit = limit,
            Skip = skip,
            DocumentsIds = { query.DocumentIds ?? [] }
        };

        return result;
    }
}
