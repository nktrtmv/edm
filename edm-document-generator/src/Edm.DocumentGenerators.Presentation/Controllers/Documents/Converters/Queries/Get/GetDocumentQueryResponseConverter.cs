using Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed;
using Edm.DocumentGenerators.Presentation.Abstractions;
using Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Queries.Get.Contracts.Detailed;

namespace Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Queries.Get;

internal static class GetDocumentQueryResponseConverter
{
    internal static GetDocumentQueryResponse FromInternal(DocumentDetailedInternal model)
    {
        DocumentDetailedDto document = DocumentDetailedDtoConverter.FromInternal(model);

        var result = new GetDocumentQueryResponse
        {
            Document = document
        };

        return result;
    }
}
