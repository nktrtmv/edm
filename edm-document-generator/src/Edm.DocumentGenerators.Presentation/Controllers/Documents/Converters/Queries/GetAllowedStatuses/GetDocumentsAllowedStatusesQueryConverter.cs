using Edm.DocumentGenerators.Application.Documents.Queries.GetAllowedStatuses.Contracts;
using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Queries.GetAllowedStatuses;

internal static class GetDocumentsAllowedStatusesQueryConverter
{
    public static GetDocumentsAllowedStatusesQueryInternal ToInternal(GetDocumentsAllowedStatusesQuery query)
    {
        var result = new GetDocumentsAllowedStatusesQueryInternal(query.DocumentsIds.ToArray());

        return result;
    }
}
