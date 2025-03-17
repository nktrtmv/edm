using Edm.Document.Classifier.Domain.Entities.DocumentClassifications.Markers;
using Edm.Document.Classifier.ExternalServices.DocumentsTemplates.Contracts.Queries.GetDetails;
using Edm.Document.Classifier.GenericSubdomain;
using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.Document.Classifier.ExternalServices.DocumentGenerators.Converters;

internal static class GetDetailsDocumentsTemplatesQueryExternalResponseConverter
{
    internal static GetDetailsDocumentsTemplatesQueryExternalResponse FromDto(GetDetailsDocumentsTemplatesDetailsQueryResponse response)
    {
        Id<DocumentTemplate>[] documentTemplateIds = response.Templates
            .Select(t => IdConverterFrom<DocumentTemplate>.FromString(t.Id))
            .ToArray();

        var result = new GetDetailsDocumentsTemplatesQueryExternalResponse(documentTemplateIds);

        return result;
    }
}
