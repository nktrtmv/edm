using Edm.DocumentGenerators.Application.DocumentTemplates.Queries.GetAll.Contracts;
using Edm.DocumentGenerators.Presentation.Abstractions;
using Edm.DocumentGenerators.Presentation.Controllers.DocumentsTemplates.Converters.Queries.GetAll.Contracts.Slim;

namespace Edm.DocumentGenerators.Presentation.Controllers.DocumentsTemplates.Converters.Queries.GetAll;

internal static class GetAllDocumentTemplatesQueryResponseConverter
{
    internal static GetAllDocumentTemplatesQueryResponse FromInternal(GetAllDocumentTemplatesQueryInternalResponse response)
    {
        DocumentTemplateSlimDto[] templates = response.Templates.Select(DocumentTemplateSlimDtoConverter.FromInternal).ToArray();

        var result = new GetAllDocumentTemplatesQueryResponse
        {
            Templates = { templates }
        };

        return result;
    }
}
