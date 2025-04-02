using Edm.Document.Searcher.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Documents;
using Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.Contracts.Filters.Inheritors;
using Edm.DocumentGenerator.Gateway.GenericSubdomain.Exceptions.Arguments;

namespace Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.Contracts.Filters;

internal static class SearchDocumentsQueryFilterBffConverter
{
    internal static SearchDocumentsQueryFilter ToDto(SearchDocumentsQueryFilterBff filter, DomainRoles domainRoles)
    {
        var result = filter switch
        {
            SearchDocumentsQueryContainsFilterBff f => SearchDocumentsQueryContainsFilterBffConverter.ToDto(f, domainRoles),
            SearchDocumentsQueryMatchFilterBff f => SearchDocumentsQueryMatchFilterBffConverter.ToDto(f, domainRoles),
            SearchDocumentsQueryRangeFilterBff f => SearchDocumentsQueryRangeFilterBffConverter.ToDto(f, domainRoles),
            _ => throw new ArgumentTypeOutOfRangeException(filter)
        };

        return result;
    }
}
