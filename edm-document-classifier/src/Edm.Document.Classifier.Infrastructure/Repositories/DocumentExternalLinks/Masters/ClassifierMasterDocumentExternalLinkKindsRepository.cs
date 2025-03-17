using Edm.Document.Classifier.Domain.Entities.DocumentExternalLinks.ValueObjects.Classifications;
using Edm.Document.Classifier.Domain.Entities.DocumentExternalLinks.ValueObjects.Kinds.MasterKinds;
using Edm.Document.Classifier.Infrastructure.Abstractions.Repositories.DocumentExternalLinks.Masters;
using Edm.Document.Classifier.Infrastructure.Repositories.DocumentExternalLinks.Contracts.ClassificationNodes;
using Edm.Document.Classifier.Infrastructure.Repositories.DocumentExternalLinks.Contracts.ClassificationNodes.Services.Detectors;
using Edm.Document.Classifier.Infrastructure.Repositories.DocumentExternalLinks.Masters.Providers.Masters;

namespace Edm.Document.Classifier.Infrastructure.Repositories.DocumentExternalLinks.Masters;

internal sealed class ClassifierMasterDocumentExternalLinkKindsRepository : IClassifierMasterDocumentExternalLinkKindsRepository
{
    private static readonly Dictionary<ContractsClassifierMasterDocumentExternalLinkKind, ClassifierDocumentClassificationNode[]> Kinds =
        new Dictionary<ContractsClassifierMasterDocumentExternalLinkKind, ClassifierDocumentClassificationNode[]>
        {
            { ContractsClassifierMasterDocumentExternalLinkKind.Rent, ClassifierMasterDocumentExternalLinkKindClassificationsProviders.Rent },
            { ContractsClassifierMasterDocumentExternalLinkKind.Ppsm, ClassifierMasterDocumentExternalLinkKindClassificationsProviders.Ppsm },
            { ContractsClassifierMasterDocumentExternalLinkKind.RealizationContracts, ClassifierMasterDocumentExternalLinkKindClassificationsProviders.RealizationContracts },
            { ContractsClassifierMasterDocumentExternalLinkKind.PurchaseContracts, ClassifierMasterDocumentExternalLinkKindClassificationsProviders.PurchaseContracts },
            { ContractsClassifierMasterDocumentExternalLinkKind.MarketingSalesContracts, ClassifierMasterDocumentExternalLinkKindClassificationsProviders.MarketingSalesContracts },
            { ContractsClassifierMasterDocumentExternalLinkKind.DcOtherContracts, ClassifierMasterDocumentExternalLinkKindClassificationsProviders.DcOtherContracts },
            { ContractsClassifierMasterDocumentExternalLinkKind.DcOtherAdditionalAgreements, ClassifierMasterDocumentExternalLinkKindClassificationsProviders.DcOtherAdditionalAgreements }
        };

    Task<ContractsClassifierMasterDocumentExternalLinkKind?> IClassifierMasterDocumentExternalLinkKindsRepository.GetKind(
        ClassifierDocumentClassification classification,
        CancellationToken cancellationToken)
    {
        ContractsClassifierMasterDocumentExternalLinkKind? result = null;

        foreach ((ContractsClassifierMasterDocumentExternalLinkKind kind, ClassifierDocumentClassificationNode[] classifications) in Kinds)
        {
            if (ClassifierDocumentClassificationMatcher.IsMatched(classification, classifications))
            {
                result = kind;

                break;
            }
        }

        return Task.FromResult(result);
    }
}
