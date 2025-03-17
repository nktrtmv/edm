using Edm.DocumentGenerator.Gateway.Core.Domains;
using Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.Domains;
using Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.RegistryRoles;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentsAttributesRoles.RegistryRoles.Queries.Get;

public sealed class GetAllDocumentDomainsService(IDocumentsRegistryRolesClient roles)
{
    public async Task<GetDomainsQueryResponseBff> GetAll(
        GetDomainsQueryBff query,
        CancellationToken cancellationToken)
    {
        DomainExternal[] domains = await roles.GetDomains(query.Query, cancellationToken);

        var items = domains.Select(
                x =>
                {
                    var documentsSettings = new DocumentsSettingsBff(
                        x.DocumentsSettings.DisableManualCreation,
                        x.DocumentsSettings.RegistryTitle,
                        x.DocumentsSettings.DetailsTitle,
                        x.DocumentsSettings.CreationTitle);

                    var commentsSettings = new CommentsSettingsBff(x.CommentsSettings.EntityType);

                    return new DomainBff(
                        x.Id,
                        x.Name,
                        (DomainDocumentCreationType)x.DocumentCreationType,
                        documentsSettings,
                        commentsSettings,
                        x.UrlAlias);
                })
            .ToList();

        var result = new GetDomainsQueryResponseBff(items);

        return result;
    }
}
