using Edm.Entities.Approval.Rules.Gateway.ExternalServices.DocumentClassifier.Clients.Queries.GetAllDomains.Contracts;

namespace Edm.Entities.Approval.Rules.Gateway.ExternalServices.DocumentClassifier.Clients;

public interface IDocumentClassifierDomainsClient
{
    Task<GetAllDomainsQueryResponseExternal> GetAllDomains(CancellationToken cancellationToken);
}
