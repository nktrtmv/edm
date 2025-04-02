using Edm.DocumentGenerators.Application.Contracts.Statuses;
using Edm.DocumentGenerators.Application.Documents.Queries.GetShortestPathToCompletion.Contracts;
using Edm.DocumentGenerators.Application.Documents.Services;
using Edm.DocumentGenerators.Domain.Entities.Documents;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Detectors.ShortestPathToCompletion;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses;
using Edm.DocumentGenerators.GenericSubdomain;

using JetBrains.Annotations;

using MediatR;

namespace Edm.DocumentGenerators.Application.Documents.Queries.GetShortestPathToCompletion;

[UsedImplicitly]
internal sealed class GetShortestPathToCompletionQueryHandlerInternal
    : IRequestHandler<GetShortestPathToCompletionQueryRequestInternal, GetShortestPathToCompletionQueryResponseInternal>
{
    public GetShortestPathToCompletionQueryHandlerInternal(DocumentsFacade documents)
    {
        Documents = documents;
    }

    private DocumentsFacade Documents { get; }

    public async Task<GetShortestPathToCompletionQueryResponseInternal> Handle(
        GetShortestPathToCompletionQueryRequestInternal request,
        CancellationToken cancellationToken)
    {
        Id<Document> documentId = IdConverterFrom<Document>.From(request.DocumentId);

        Document document = await Documents.GetRequired(documentId, cancellationToken);

        DocumentStatus[] path = DocumentShortestPathToCompletionDetect.Detect(document.StatusStateMachine, document.Status);

        DocumentStatusInternal[] pathInternal = path.Select(DocumentStatusInternalConverter.FromDomain).ToArray();

        var result = new GetShortestPathToCompletionQueryResponseInternal(pathInternal);

        return result;
    }
}
