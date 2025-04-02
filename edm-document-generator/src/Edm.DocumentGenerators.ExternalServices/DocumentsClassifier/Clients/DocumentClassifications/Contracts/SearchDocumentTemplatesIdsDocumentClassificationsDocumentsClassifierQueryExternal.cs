using Edm.DocumentGenerators.ExternalServices.DocumentsClassifier.Contracts.Classifications;

namespace Edm.DocumentGenerators.ExternalServices.DocumentsClassifier.Clients.DocumentClassifications.Contracts;

public sealed class SearchDocumentTemplatesIdsDocumentClassificationsDocumentsClassifierQueryExternal
{
    public SearchDocumentTemplatesIdsDocumentClassificationsDocumentsClassifierQueryExternal(DocumentClassifierClassificationExternal classification)
    {
        Classification = classification;
    }

    public DocumentClassifierClassificationExternal Classification { get; }
}
