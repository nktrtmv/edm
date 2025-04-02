using Edm.DocumentGenerators.Domain.Entities.Documents;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Tokens.Concurrency;

namespace Edm.DocumentGenerators.Infrastructure.Abstractions.Repositories.Documents;

public interface IDocumentsRepository
{
    Task<Document?> Get(Id<Document> documentId, CancellationToken cancellationToken);
    Task<Document> GetRequired(Id<Document> documentId, CancellationToken cancellationToken);
    Task<Document> GetRequired(DomainId domainId, Id<Document> documentId, CancellationToken cancellationToken);
    Task<Document[]> Search(HashSet<Id<Document>> documentsIds, CancellationToken cancellationToken);
    Task<Id<Document>[]> GetAllIds(DomainId domainId, CancellationToken cancellationToken);
    Task<ConcurrencyToken<Document>> Upsert(Document document, CancellationToken cancellationToken);
    Task DeleteByIds(DomainId domainId, HashSet<Id<Document>> documentsIds, CancellationToken cancellationToken);
}
