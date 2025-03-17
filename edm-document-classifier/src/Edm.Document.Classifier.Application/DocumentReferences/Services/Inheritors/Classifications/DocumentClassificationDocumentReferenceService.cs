using Edm.Document.Classifier.Domain.Entities.DocumentClassifications;
using Edm.Document.Classifier.Domain.Entities.DocumentClassifications.Markers;
using Edm.Document.Classifier.GenericSubdomain;
using Edm.Document.Classifier.Infrastructure.Abstractions.Repositories;
using Edm.Document.Classifier.Infrastructure.Abstractions.Repositories.DocumentClassifications;

namespace Edm.Document.Classifier.Application.DocumentReferences.Services.Inheritors.Classifications;

public abstract class DocumentClassificationDocumentReferenceService(
    IDocumentClassificationRepository classificationsRepository,
    IDocumentClassifierRepository classifiersRepository)
    : DocumentReferenceService
{
    protected IDocumentClassifierRepository ClassifiersRepository { get; } = classifiersRepository;

    protected async Task<DocumentClassification> GetClassification(string templateId, CancellationToken cancellationToken)
    {
        Id<DocumentTemplate> id = IdConverterFrom<DocumentTemplate>.FromString(templateId);

        DocumentClassification result = await classificationsRepository.GetRequired(id, cancellationToken);

        return result;
    }
}
