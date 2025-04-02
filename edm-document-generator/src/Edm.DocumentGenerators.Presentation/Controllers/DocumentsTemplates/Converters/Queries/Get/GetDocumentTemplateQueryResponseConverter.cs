using Edm.DocumentGenerators.Application.DocumentTemplates.Queries.Get.Contracts;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.Presentation.Abstractions;
using Edm.DocumentGenerators.Presentation.Controllers.DocumentsTemplates.Converters.Queries.Get.Contracts.Detailed;

namespace Edm.DocumentGenerators.Presentation.Controllers.DocumentsTemplates.Converters.Queries.Get;

internal static class GetDocumentTemplateQueryResponseConverter
{
    internal static GetDocumentTemplateQueryResponse FromInternal(GetDocumentTemplateQueryInternalResponse response)
    {
        DocumentTemplateDetailedDto? template = NullableConverter.Convert(response.Template, DocumentTemplateDetailedDtoConverter.FromInternal);

        var result = new GetDocumentTemplateQueryResponse
        {
            Template = template
        };

        return result;
    }
}
