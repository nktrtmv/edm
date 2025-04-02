using Edm.Document.Searcher.Presentation.Abstractions;

using Grpc.Core;

using Microsoft.Extensions.DependencyInjection;

using Edm.DocumentGenerator.Gateway.Core.Contracts.Users;
using Edm.DocumentGenerator.Gateway.Core.Documents;
using Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.GetAll.Contracts;
using Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.GetAll.Contracts.Contracts.Documents;
using Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.Services.Enrichment;
using Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.Services.Enrichment.Context;
using Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.Services.QuickFilters;
using Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.RegistryRoles;

namespace Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.GetAll;

public sealed class GetAllDocumentsService(
    IDocumentsRegistryRolesClient registryRolesClient,
    SearchDocumentsService.SearchDocumentsServiceClient documentsClient,
    SearchDocumentsQuickFiltersService searchDocumentsQuickFiltersService,
    IRoleAdapter roleAdapter,
    IServiceProvider serviceProvider)
{
    public async Task<GetAllDocumentsQueryBffResponse> GetAll(
        UserBff user,
        GetAllDocumentsQueryBff queryBff,
        int skip,
        int limit,
        CancellationToken cancellationToken)
    {
        var quickFilter = searchDocumentsQuickFiltersService.ConvertToSearchDocumentQueryFilters(queryBff.DomainId, queryBff.Filter, user);

        var roles = await roleAdapter.GetDomainRoles(queryBff.DomainId, cancellationToken);
        queryBff.Filters.AddRange(quickFilter);

        var query = GetAllDocumentsQueryBffConverter.ToDto(queryBff, skip, limit, roles);

        var responseDocuments = new List<GetDocumentsQueryResponseSearchDocument>();

        using AsyncServerStreamingCall<GetDocumentsQueryResponseSearchDocument> call = documentsClient.Get(query, cancellationToken: cancellationToken);

        await foreach (var document in call.ResponseStream.ReadAllAsync(cancellationToken))
        {
            responseDocuments.Add(document);
        }

        var enricher = serviceProvider.GetRequiredService<GetAllDocumentsQueryResponseDocumentBffEnricher>(); // TODO: rewrife from transient
        var conversionContext = new GetAllDocumentsQueryResponseDocumentBffContext(enricher);

        var registryRoles = await registryRolesClient.Get(queryBff.DomainId, cancellationToken);

        var documents = responseDocuments
            .Select(d => GetAllDocumentsQueryResponseDocumentBffConverter.FromDto(d, registryRoles, conversionContext, roles))
            .ToArray();

        await enricher.Enrich(cancellationToken);

        var result = GetAllDocumentsQueryBffResponseConverter.FromInternal(documents);

        return result;
    }
}
