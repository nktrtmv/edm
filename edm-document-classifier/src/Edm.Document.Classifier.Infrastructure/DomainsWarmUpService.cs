using Edm.Document.Classifier.Infrastructure.Abstractions.Repositories;

namespace Edm.Document.Classifier.Infrastructure;

public sealed class DomainsWarmUpService(IDomainRepository domainRepository)
{
    public Task WarmUp(CancellationToken cancellationToken = default)
    {
        return domainRepository.GetAllDomains(cancellationToken);
    }
}
