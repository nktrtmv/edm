using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates;
using Edm.DocumentGenerators.ExternalServices.DocumentsClassifier.Clients.DocumentClassifications.Contracts;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Application.Documents.Commands.Create.ByClassification.Services.Searchers.Converters;

internal static class SearchDocumentTemplatesIdsDocumentClassificationsDocumentsClassifierQueryExternalResponseConverter
{
    internal static Id<DocumentTemplate>[] ToDomain(SearchDocumentTemplatesIdsDocumentClassificationsDocumentsClassifierQueryExternalResponse response)
    {
        Id<DocumentTemplate>[] result = response.TemplatesIds.Select(IdConverterFrom<DocumentTemplate>.From).ToArray();

        return result;
    }
}
