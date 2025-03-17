using Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.DomainActions.Contracts;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.DomainActions;

public interface IDomainActionsClient
{
    Task<DomainActionsExternal> Get(string domainId, CancellationToken cancellationToken);
}
