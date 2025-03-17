using Edm.Document.Searcher.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Documents;
using Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.Contracts.Filters;
using Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.Contracts.SortParameters;

namespace Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.Count.Contracts;

internal static class GetDocumentsCountQueryBffConverter
{
    internal static SearchDocumentsQuery ToDto(
        GetDocumentsCountQueryBff query,
        DomainRoles domainRoles)
    {
        var filters =
            query.Filters.Select(x => SearchDocumentsQueryFilterBffConverter.ToDto(x, domainRoles)).ToArray();

        var sortParameters =
            SearchDocumentsQuerySortParametersBffConverter.ToDto(null, domainRoles);

        var result = new SearchDocumentsQuery
        {
            DomainId = query.DomainId,
            Filters = { filters },
            SortParameters = sortParameters,
            Limit = int.MaxValue,
            Skip = 0
        };

        return result;
    }
}
