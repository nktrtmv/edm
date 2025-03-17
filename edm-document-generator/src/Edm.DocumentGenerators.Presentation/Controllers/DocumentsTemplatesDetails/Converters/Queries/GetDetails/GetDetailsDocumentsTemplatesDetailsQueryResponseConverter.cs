using Edm.DocumentGenerators.Application.DocumentsTemplatesDetails.Queries.GetDetails.Contracts;
using Edm.DocumentGenerators.Presentation.Abstractions;
using Edm.DocumentGenerators.Presentation.Controllers.DocumentsTemplatesDetails.Converters.Queries.GetDetails.Templates;

namespace Edm.DocumentGenerators.Presentation.Controllers.DocumentsTemplatesDetails.Converters.Queries.GetDetails;

internal static class GetDetailsDocumentsTemplatesDetailsQueryResponseConverter
{
    internal static GetDetailsDocumentsTemplatesDetailsQueryResponse FromInternal(GetDetailsDocumentsTemplatesDetailsQueryInternalResponse response)
    {
        GetDetailsDocumentsTemplatesDetailsQueryResponseTemplate[] templates =
            response.Templates.Select(GetDetailsDocumentsTemplatesDetailsQueryResponseTemplateConverter.FromInternal).ToArray();

        var result = new GetDetailsDocumentsTemplatesDetailsQueryResponse
        {
            Templates = { templates }
        };

        return result;
    }
}
