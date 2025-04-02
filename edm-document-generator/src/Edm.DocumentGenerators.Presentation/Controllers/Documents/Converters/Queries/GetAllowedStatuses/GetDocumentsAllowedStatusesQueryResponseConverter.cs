using Edm.DocumentGenerators.Application.Documents.Queries.GetAllowedStatuses.Contracts;
using Edm.DocumentGenerators.Presentation.Abstractions;
using Edm.DocumentGenerators.Presentation.Controllers.Converters.Statuses;

namespace Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Queries.GetAllowedStatuses;

internal static class GetDocumentsAllowedStatusesQueryResponseConverter
{
    public static GetDocumentsAllowedStatusesQueryResponse FromInternal(GetDocumentsAllowedStatusesQueryResponseInternal response)
    {
        DocumentStatusDto[] statuses = response.Statuses.Select(DocumentStatusDtoConverter.FromInternal).ToArray();

        var result = new GetDocumentsAllowedStatusesQueryResponse
        {
            Statuses = { statuses }
        };

        return result;
    }
}
