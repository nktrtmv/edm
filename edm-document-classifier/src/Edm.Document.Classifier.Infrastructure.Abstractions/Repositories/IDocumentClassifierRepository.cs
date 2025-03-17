using Edm.Document.Classifier.Domain.Entities.DocumentClassifiers;

namespace Edm.Document.Classifier.Infrastructure.Abstractions.Repositories;

public interface IDocumentClassifierRepository
{
    Task<DocumentClassifier> Get(CancellationToken cancellationToken);
}
