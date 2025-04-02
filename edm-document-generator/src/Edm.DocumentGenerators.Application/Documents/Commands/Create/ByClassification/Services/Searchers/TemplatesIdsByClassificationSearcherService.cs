using Edm.DocumentGenerators.Application.Documents.Commands.Create.ByClassification.Services.Searchers.Converters;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates;
using Edm.DocumentGenerators.Domain.ValueObjects.Classifications;
using Edm.DocumentGenerators.ExternalServices.DocumentsClassifier.Clients.DocumentClassifications;
using Edm.DocumentGenerators.ExternalServices.DocumentsClassifier.Clients.DocumentClassifications.Contracts;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Application.Documents.Commands.Create.ByClassification.Services.Searchers;

public sealed class TemplatesIdsByClassificationSearcherService
{
    public TemplatesIdsByClassificationSearcherService(IDocumentClassificationsDocumentsClassifierClient classifications)
    {
        Classifications = classifications;
    }

    private IDocumentClassificationsDocumentsClassifierClient Classifications { get; }

    internal async Task<Id<DocumentTemplate>[]> Search(DocumentClassification classification, CancellationToken cancellationToken)
    {
        SearchDocumentTemplatesIdsDocumentClassificationsDocumentsClassifierQueryExternal request =
            SearchDocumentTemplatesIdsDocumentClassificationsDocumentsClassifierQueryExternalConverter.FromDomain(classification);

        SearchDocumentTemplatesIdsDocumentClassificationsDocumentsClassifierQueryExternalResponse response =
            await Classifications.Search(request, cancellationToken);

        Id<DocumentTemplate>[] result =
            SearchDocumentTemplatesIdsDocumentClassificationsDocumentsClassifierQueryExternalResponseConverter.ToDomain(response);

        return result;
    }
}
