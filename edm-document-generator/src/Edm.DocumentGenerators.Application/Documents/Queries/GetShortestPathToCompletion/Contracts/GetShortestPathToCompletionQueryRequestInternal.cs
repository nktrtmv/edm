using Edm.DocumentGenerators.Application.Contracts.Markers;
using Edm.DocumentGenerators.GenericSubdomain;

using MediatR;

namespace Edm.DocumentGenerators.Application.Documents.Queries.GetShortestPathToCompletion.Contracts;

public sealed class GetShortestPathToCompletionQueryRequestInternal : IRequest<GetShortestPathToCompletionQueryResponseInternal>
{
    public GetShortestPathToCompletionQueryRequestInternal(Id<DocumentInternal> documentId)
    {
        DocumentId = documentId;
    }

    internal Id<DocumentInternal> DocumentId { get; }
}
