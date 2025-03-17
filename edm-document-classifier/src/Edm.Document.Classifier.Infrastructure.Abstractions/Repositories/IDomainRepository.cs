using Edm.Document.Classifier.Domain.Entities.DocumentDomains;
using Edm.Document.Classifier.Domain.ValueObjects.DocumentDomains;

namespace Edm.Document.Classifier.Infrastructure.Abstractions.Repositories;

public interface IDomainRepository
{
    Task<DocumentDomains> GetAllDomains(CancellationToken cancellationToken);
    Task<DocumentDomain?> GetDomainById(DomainId id, CancellationToken cancellationToken);
    Task<DocumentDomain> GetDomainByIdRequired(DomainId id, CancellationToken cancellationToken);
}
