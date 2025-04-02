using Edm.Document.Searcher.Application.Documents.Contracts.RegistryRoles;
using Edm.Document.Searcher.Application.Documents.Queries.Get.Contracts;
using Edm.Document.Searcher.Application.Documents.Queries.Get.Contracts.Documents;
using Edm.Document.Searcher.Domain.Documents;
using Edm.Document.Searcher.Domain.Documents.ValueObjects;
using Edm.Document.Searcher.ExternalServices.DocumentClassifier.RegistryRoles;
using Edm.Document.Searcher.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.Domains.Roles;
using Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments;
using Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments.Contracts.Queries.Get;

using JetBrains.Annotations;

using MediatR;

namespace Edm.Document.Searcher.Application.Documents.Queries.Get;

[UsedImplicitly]
internal sealed class GetDocumentsQueryHandlerInternal(ISearchDocumentsRepository documents, IDocumentsRegistryRolesClient documentsRegistryRoles)
    : IRequestHandler<GetDocumentsQueryInternal, GetDocumentsQueryInternalResponse>
{
    private ISearchDocumentsRepository Documents { get; } = documents;
    private IDocumentsRegistryRolesClient DocumentsRegistryRoles { get; } = documentsRegistryRoles;

    public async Task<GetDocumentsQueryInternalResponse> Handle(GetDocumentsQueryInternal request, CancellationToken cancellationToken)
    {
        DomainId domainId = DomainId.Parse(request.DomainId);

        DocumentRegistryRoleExternal[] documentsRegistryRoles = await DocumentsRegistryRoles.Get(domainId, cancellationToken);

        if (request.Filters.Length != 0 && request.Filters.All(x => x.RegistryRolesIds.Length == 0))
        {
            return new GetDocumentsQueryInternalResponse([]);
        }

        SearchDocumentRegistryRoleInternal[] registryRoles = documentsRegistryRoles.Select(SearchDocumentRegistryRoleInternalConverter.FromExternal).ToArray();

        GetDocumentsQuery query = GetDocumentsQueryInternalConverter.ToDomain(request, registryRoles);

        SearchDocument[] response = await Documents.Get(query, cancellationToken);

        GetDocumentsQueryInternalResponseSearchDocument[] documents =
            response.Select(GetDocumentsQueryInternalResponseSearchDocumentInternalConverter.FromDomain).ToArray();

        var result = new GetDocumentsQueryInternalResponse(documents);

        return result;
    }
}
