using Edm.Document.Classifier.Domain.Entities.DocumentExternalLinks.ValueObjects.Classifications;
using Edm.Document.Classifier.Domain.Entities.DocumentExternalLinks.ValueObjects.Kinds.MasterKinds;

namespace Edm.Document.Classifier.Infrastructure.Abstractions.Repositories.DocumentExternalLinks.Masters;

public interface IClassifierMasterDocumentExternalLinkKindsRepository
{
    Task<ContractsClassifierMasterDocumentExternalLinkKind?> GetKind(ClassifierDocumentClassification classification, CancellationToken cancellationToken);
}
