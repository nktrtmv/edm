using Edm.DocumentGenerators.Application.Contracts.Markers;
using Edm.DocumentGenerators.Application.Documents.Queries.GetShortestPathToCompletion.Contracts;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Queries.GetShortestPathToCompletion;

internal static class GetShortestPathToCompletionQueryRequestConverter
{
    internal static GetShortestPathToCompletionQueryRequestInternal ToInternal(GetShortestPathToCompletionQueryRequest request)
    {
        Id<DocumentInternal> documentId = IdConverterFrom<DocumentInternal>.FromString(request.DocumentId);

        var result = new GetShortestPathToCompletionQueryRequestInternal(documentId);

        return result;
    }
}
