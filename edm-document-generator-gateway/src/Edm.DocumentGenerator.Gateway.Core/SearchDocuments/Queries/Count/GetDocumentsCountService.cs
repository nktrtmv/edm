using Edm.Document.Searcher.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Contracts.Users;
using Edm.DocumentGenerator.Gateway.Core.Documents;
using Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.Count.Contracts;
using Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.Services.QuickFilters;

namespace Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.Count;

public sealed class GetDocumentsCountService(
    SearchDocumentsService.SearchDocumentsServiceClient documentsClient,
    SearchDocumentsQuickFiltersService searchDocumentsQuickFiltersService,
    IRoleAdapter roleAdapter)
{
    public async Task<GetDocumentsCountResponseBff> Count(
        UserBff user,
        GetDocumentsCountQueryBff queryBff,
        CancellationToken cancellationToken)
    {
        var mineFilters = searchDocumentsQuickFiltersService.ConvertToSearchDocumentQueryFilters(queryBff.DomainId, queryBff.Filter, user);

        queryBff.Filters.AddRange(mineFilters);

        var roles = await roleAdapter.GetDomainRoles(queryBff.DomainId, cancellationToken);
        var query = GetDocumentsCountQueryBffConverter.ToDto(queryBff, roles);

        var response = await documentsClient.SearchAsync(query, cancellationToken: cancellationToken);

        var result = new GetDocumentsCountResponseBff(response.DocumentsIds.Count);

        return result;
    }
}
