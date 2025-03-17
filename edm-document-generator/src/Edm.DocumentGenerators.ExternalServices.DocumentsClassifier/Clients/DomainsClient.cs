using Edm.Document.Classifier.Presentation.Abstractions;
using Edm.DocumentGenerators.ExternalServices.DocumentsClassifier.Clients.Domains;

namespace Edm.DocumentGenerators.ExternalServices.DocumentsClassifier.Clients;

internal sealed class DomainsClient(DocumentRegistryRolesService.DocumentRegistryRolesServiceClient client) : IDomainsClient
{
    public async Task<List<DomainExternal>> GetAllDomains(CancellationToken cancellationToken)
    {
        GetAllDomainsV2.Types.Response? response = await client.GetAllDomainsV2Async(new GetAllDomainsV2.Types.Query(), cancellationToken: cancellationToken);

        List<DomainExternal> result = response.Domains.Select(x => new DomainExternal(x.DomainId, x.DomainName)).ToList();

        return result;
    }
}
