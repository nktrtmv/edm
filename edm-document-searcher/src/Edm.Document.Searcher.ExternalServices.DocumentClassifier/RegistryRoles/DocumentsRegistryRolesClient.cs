using Edm.Document.Classifier.Presentation.Abstractions;
using Edm.Document.Searcher.Domain.Documents.ValueObjects;
using Edm.Document.Searcher.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.Domains.Roles;
using Edm.Document.Searcher.ExternalServices.DocumentClassifier.RegistryRoles.Converters;

using JetBrains.Annotations;

using Microsoft.Extensions.Caching.Memory;

namespace Edm.Document.Searcher.ExternalServices.DocumentClassifier.RegistryRoles;

[UsedImplicitly]
internal sealed class DocumentsRegistryRolesClient : IDocumentsRegistryRolesClient
{
    public DocumentsRegistryRolesClient(DocumentRegistryRolesService.DocumentRegistryRolesServiceClient client, IMemoryCache memoryCache)
    {
        Client = client;
        MemoryCache = memoryCache;
    }

    private DocumentRegistryRolesService.DocumentRegistryRolesServiceClient Client { get; }
    private IMemoryCache MemoryCache { get; }

    public async Task<DocumentRegistryRoleExternal[]> Get(DomainId domainId, CancellationToken cancellationToken)
    {
        DocumentRegistryRoleExternal[]? result = await MemoryCache.GetOrCreateAsync(
            domainId,
            async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(10);

                DocumentRegistryRoleExternal[] registryRoles = await GetRegistryRoles(domainId, cancellationToken);

                return registryRoles;
            });

        if (result is null)
        {
            throw new ApplicationException($"Domain (id: {domainId}) is not found.");
        }

        return result;
    }

    private async Task<DocumentRegistryRoleExternal[]> GetRegistryRoles(DomainId domainId, CancellationToken cancellationToken)
    {
        var query = new GetDomainRegistryRoles.Types.Query
        {
            DomainId = domainId.Value
        };

        GetDomainRegistryRoles.Types.Response response = await Client.GetDomainRegistryRolesAsync(query, cancellationToken: cancellationToken);

        DocumentRegistryRoleExternal[] result = response.DomainAttributesRoles.Select(DocumentRegistryRoleDtoConverter.ToExternal).ToArray();

        return result;
    }
}
