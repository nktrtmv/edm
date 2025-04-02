using Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.Contracts.Filters;
using Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.Contracts.SortParameters;
using Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.Services.QuickFilters.Contracts;

namespace Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.GetAll.Contracts;

public sealed class GetAllDocumentsQueryBff
{
    public required string DomainId { get; init; }

    public List<SearchDocumentsQueryFilterBff> Filters { get; init; } = [];

    public SearchDocumentsQuickFilterBff? Filter { get; init; }

    public SearchDocumentsQuerySortParametersBff? SortParameters { get; init; }

    public string[]? DocumentIds { get; init; }
}
