using Edm.Document.Classifier.ExternalServices.DocumentsTemplates.Contracts.Queries.GetDetails;
using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.Document.Classifier.ExternalServices.DocumentGenerators.Converters;

internal static class GetDetailsDocumentsTemplatesQueryExternalConverter
{
    internal static GetDetailsDocumentsTemplatesDetailsQuery ToDto(GetDetailsDocumentsTemplatesQueryExternal query)
    {
        string[] templatesIds = query.DocumentTemplateIds.Select(id => id.ToString()).ToArray();

        var result = new GetDetailsDocumentsTemplatesDetailsQuery()
        {
            TemplatesIds = { templatesIds }
        };

        return result;
    }
}
