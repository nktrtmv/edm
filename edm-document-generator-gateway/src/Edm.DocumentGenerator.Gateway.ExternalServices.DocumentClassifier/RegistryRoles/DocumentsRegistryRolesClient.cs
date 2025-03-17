using Edm.Document.Classifier.Presentation.Abstractions;

using Grpc.Core;

using JetBrains.Annotations;

using Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.Domains;
using Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.DocumentsAttributes;
using Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.Roles;
using Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.RegistryRoles.Converters.DocumentsAttributes;
using Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.RegistryRoles.Converters.Roles;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.RegistryRoles;

[UsedImplicitly]
internal sealed class DocumentsRegistryRolesClient(DocumentRegistryRolesService.DocumentRegistryRolesServiceClient client)
    : IDocumentsRegistryRolesClient
{
    public async Task<DocumentRegistryRoleExternal[]> Get(string domainId, CancellationToken cancellationToken)
    {
        DocumentRegistryRoleExternal[] registryRoles = await GetRegistryRoles(domainId, cancellationToken);

        return registryRoles;
    }

    public async Task<DocumentAttributeDocumentRegistryRolesExternal[]> GetDocumentsAttributes(string domainId, CancellationToken cancellationToken)
    {
        DocumentAttributeDocumentRegistryRolesExternal[] registryRoles = await GetAllDocumentsAttributesRegistryRoles(domainId, cancellationToken);

        return registryRoles;
    }

    public async Task<DomainExternal[]> GetDomains(string? query, CancellationToken cancellationToken)
    {
        var request = new GetAllDomainsV2.Types.Query();
        var response = await client.GetAllDomainsV2Async(request, cancellationToken: cancellationToken);

        var targetItems = !string.IsNullOrWhiteSpace(query)
            ? response.Domains.Where(x => x.DomainId.Contains(query, StringComparison.OrdinalIgnoreCase))
            : response.Domains;

        DomainExternal[] items = targetItems.Select(ToExternal).ToArray();

        return items;
    }

    public async Task<DomainExternal?> GetDomainById(string domainId, CancellationToken cancellationToken)
    {
        var request = new GetDomainById.Types.Query { DomainId = domainId };

        try
        {
            var response = await client.GetDomainByIdAsync(request, cancellationToken: cancellationToken);
            var domain = ToExternal(response.Domain);

            return domain;
        }
        catch (RpcException e) when (e.Status.StatusCode is StatusCode.InvalidArgument)
        {
            return null;
        }
    }

    private static DomainExternal ToExternal(DomainDto model)
    {
        var documentSettings = model.DocumentsSettings;

        var externalDocumentsSettings = new DocumentsSettingsExternal(
            documentSettings.DisableManualCreation,
            documentSettings.RegistryTitle,
            documentSettings.DetailsTitle,
            documentSettings.CreationTitle);

        var commentsSettings = model.CommentsSettings;
        var externalCommentsSettings = new CommentsSettingsExternal(commentsSettings.EntityType);

        var result = new DomainExternal(
            model.DomainId,
            model.DomainName,
            (int)model.DocumentCreationType,
            externalDocumentsSettings,
            externalCommentsSettings,
            model.UrlAlias);

        return result;
    }

    private async Task<DocumentAttributeDocumentRegistryRolesExternal[]> GetAllDocumentsAttributesRegistryRoles(string domainId, CancellationToken cancellationToken)
    {
        var query = new GetAllDocumentsAttributesDocumentRegistryRolesQuery { DomainId = domainId };

        var response = await client.GetAllDocumentsAttributesAsync(query, cancellationToken: cancellationToken);

        DocumentAttributeDocumentRegistryRolesExternal[] result =
            response.DocumentsAttributesRoles.Select(DocumentAttributeDocumentRegistryRolesExternalConverter.FromDto).ToArray();

        return result;
    }

    private async Task<DocumentRegistryRoleExternal[]> GetRegistryRoles(string domainIdExternal, CancellationToken cancellationToken)
    {
        var query = new GetDomainRegistryRoles.Types.Query { DomainId = domainIdExternal };

        var response = await client.GetDomainRegistryRolesAsync(query, cancellationToken: cancellationToken);

        DocumentRegistryRoleExternal[] result = response.DomainAttributesRoles
            .SelectMany(x => x.Roles)
            .Select(DocumentRegistryRoleDtoConverter.ToExternal)
            .ToArray();

        return result;
    }
}
