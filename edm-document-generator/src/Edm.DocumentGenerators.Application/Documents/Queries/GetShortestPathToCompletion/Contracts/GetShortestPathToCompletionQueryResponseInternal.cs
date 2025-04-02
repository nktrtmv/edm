using Edm.DocumentGenerators.Application.Contracts.Statuses;

namespace Edm.DocumentGenerators.Application.Documents.Queries.GetShortestPathToCompletion.Contracts;

public sealed class GetShortestPathToCompletionQueryResponseInternal
{
    public GetShortestPathToCompletionQueryResponseInternal(DocumentStatusInternal[] path)
    {
        Path = path;
    }

    public DocumentStatusInternal[] Path { get; }
}
