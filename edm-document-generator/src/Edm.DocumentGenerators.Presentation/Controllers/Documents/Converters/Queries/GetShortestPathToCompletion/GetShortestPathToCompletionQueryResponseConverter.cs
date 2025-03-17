using Edm.DocumentGenerators.Application.Documents.Queries.GetShortestPathToCompletion.Contracts;
using Edm.DocumentGenerators.Presentation.Abstractions;
using Edm.DocumentGenerators.Presentation.Controllers.Converters.Statuses;

namespace Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Queries.GetShortestPathToCompletion;

internal static class GetShortestPathToCompletionQueryResponseConverter
{
    internal static GetShortestPathToCompletionQueryResponse FromInternal(GetShortestPathToCompletionQueryResponseInternal response)
    {
        DocumentStatusDto[] path = response.Path.Select(DocumentStatusDtoConverter.FromInternal).ToArray();

        var result = new GetShortestPathToCompletionQueryResponse
        {
            Path = { path }
        };

        return result;
    }
}
