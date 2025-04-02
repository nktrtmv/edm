using Edm.Document.Classifier.Presentation.Abstractions;

namespace Edm.Document.Searcher.ExternalServices.DocumentClassifier.Domains;

internal sealed class DomainsClient(DocumentRegistryRolesService.DocumentRegistryRolesServiceClient client) : IDomainsClient
{
    public async Task<List<DomainExternal>> GetAllDomains(CancellationToken cancellationToken)
    {
        var response = await client.GetAllDomainsV2Async(new GetAllDomainsV2.Types.Query(), cancellationToken: cancellationToken);

        var result = response.Domains.Select(x => new DomainExternal(x.DomainId, x.DomainName)).ToList();

        return result;
    }

    public async Task<bool> CheckDomainExists(string domainId, CancellationToken cancellationToken)
    {
        var domains = await GetAllDomains(cancellationToken);

        return domains.Any(x => x.Id == domainId);
    }
}
