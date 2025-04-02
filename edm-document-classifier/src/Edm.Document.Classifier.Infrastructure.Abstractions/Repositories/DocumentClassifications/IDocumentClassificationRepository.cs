using Edm.Document.Classifier.Domain.Entities.DocumentClassifications;
using Edm.Document.Classifier.Domain.Entities.DocumentClassifications.Markers;
using Edm.Document.Classifier.GenericSubdomain;
using Edm.Document.Classifier.Infrastructure.Abstractions.Repositories.DocumentClassifications.Contracts;

namespace Edm.Document.Classifier.Infrastructure.Abstractions.Repositories.DocumentClassifications;

public interface IDocumentClassificationRepository
{
    Task Upsert(DocumentClassification documentClassification, CancellationToken cancellationToken);
    Task<DocumentClassification> GetRequired(Id<DocumentTemplate> documentTemplateId, CancellationToken cancellationToken);
    Task<DocumentClassification[]> Search(DocumentClassificationSearchParams searchParams, CancellationToken cancellationToken);
}
