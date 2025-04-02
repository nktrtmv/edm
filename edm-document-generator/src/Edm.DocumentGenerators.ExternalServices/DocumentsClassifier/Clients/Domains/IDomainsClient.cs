namespace Edm.DocumentGenerators.ExternalServices.DocumentsClassifier.Clients.Domains;

public interface IDomainsClient
{
    Task<List<DomainExternal>> GetAllDomains(CancellationToken cancellationToken);
}
