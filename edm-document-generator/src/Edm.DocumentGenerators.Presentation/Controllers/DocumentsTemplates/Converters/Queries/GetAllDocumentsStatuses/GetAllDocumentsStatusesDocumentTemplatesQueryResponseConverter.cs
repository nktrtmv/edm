using Edm.DocumentGenerators.Application.DocumentTemplates.Queries.GetAllDocumentsStatuses.Contracts;
using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.DocumentGenerators.Presentation.Controllers.DocumentsTemplates.Converters.Queries.GetAllDocumentsStatuses;

internal static class GetAllDocumentsStatusesDocumentTemplatesQueryResponseConverter
{
    internal static GetAllDocumentsStatusesDocumentTemplatesQueryResponse FromInternal(GetAllDocumentsStatusesDocumentTemplatesQueryResponseInternal response)
    {
        var result = new GetAllDocumentsStatusesDocumentTemplatesQueryResponse
        {
            Statuses = { response.Statuses }
        };

        return result;
    }
}
