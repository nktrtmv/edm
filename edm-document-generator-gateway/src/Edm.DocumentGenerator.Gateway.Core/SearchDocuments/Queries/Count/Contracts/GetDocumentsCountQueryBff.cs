using Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.Contracts.Filters;
using Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.Services.QuickFilters.Contracts;

namespace Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.Count.Contracts;

public sealed record GetDocumentsCountQueryBff(
    string DomainId,
    List<SearchDocumentsQueryFilterBff> Filters,
    SearchDocumentsQuickFilterBff? Filter);
