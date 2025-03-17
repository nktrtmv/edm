namespace Edm.DocumentGenerator.Gateway.Core.Documents;

public interface IRoleAdapter
{
    Task<DomainRoles> GetDomainRoles(string domainId, CancellationToken cancellationToken);
}
