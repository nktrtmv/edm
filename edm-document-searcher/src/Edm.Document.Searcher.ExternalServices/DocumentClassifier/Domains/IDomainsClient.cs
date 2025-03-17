namespace Edm.Document.Searcher.ExternalServices.DocumentClassifier.Domains;

public interface IDomainsClient
{
    Task<List<DomainExternal>> GetAllDomains(CancellationToken cancellationToken);

    Task<bool> CheckDomainExists(string domainId, CancellationToken cancellationToken);
}
