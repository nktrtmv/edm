using Edm.Document.Searcher.Application.Documents.Contracts.RegistryRoles;
using Edm.Document.Searcher.Application.Documents.Markers;
using Edm.Document.Searcher.Application.Documents.Queries.Search.Contracts;
using Edm.Document.Searcher.Domain.Documents;
using Edm.Document.Searcher.Domain.Documents.ValueObjects;
using Edm.Document.Searcher.ExternalServices.DocumentClassifier.RegistryRoles;
using Edm.Document.Searcher.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.Domains.Roles;
using Edm.Document.Searcher.GenericSubdomain;
using Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments;
using Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments.Contracts.Queries.Search;

using JetBrains.Annotations;

using MediatR;

namespace Edm.Document.Searcher.Application.Documents.Queries.Search;

[UsedImplicitly]
internal sealed class SearchDocumentsQueryHandlerInternal(ISearchDocumentsRepository documents, IDocumentsRegistryRolesClient documentsRegistryRoles)
    : IRequestHandler<SearchDocumentsQueryInternal, SearchDocumentsQueryInternalResponse>
{
    private ISearchDocumentsRepository Documents { get; } = documents;
    private IDocumentsRegistryRolesClient DocumentsRegistryRoles { get; } = documentsRegistryRoles;

    public async Task<SearchDocumentsQueryInternalResponse> Handle(SearchDocumentsQueryInternal request, CancellationToken cancellationToken)
    {
        DomainId domainId = DomainId.Parse(request.DomainId);

        DocumentRegistryRoleExternal[] documentsRegistryRoles = await DocumentsRegistryRoles.Get(domainId, cancellationToken);

        if (request.Filters.Length != 0 && request.Filters.All(x => x.RegistryRolesIds.Length == 0))
        {
            return new SearchDocumentsQueryInternalResponse([]);
        }

        SearchDocumentRegistryRoleInternal[] registryRoles = documentsRegistryRoles.Select(SearchDocumentRegistryRoleInternalConverter.FromExternal).ToArray();

        SearchDocumentsQuery query = SearchDocumentsQueryInternalConverter.ToDomain(request, registryRoles);

        Id<SearchDocument>[] response = await Documents.Search(query, cancellationToken);

        Id<SearchDocumentInternal>[] documentsIds = response.Select(IdConverterFrom<SearchDocumentInternal>.From).ToArray();

        var result = new SearchDocumentsQueryInternalResponse(documentsIds);

        return result;
    }
}
