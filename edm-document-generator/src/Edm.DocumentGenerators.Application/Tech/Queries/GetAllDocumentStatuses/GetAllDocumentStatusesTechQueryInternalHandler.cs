using Edm.DocumentGenerators.Application.Contracts.Statuses;
using Edm.DocumentGenerators.Application.Documents.Services;
using Edm.DocumentGenerators.Application.Tech.Queries.GetAllDocumentStatuses.Contracts;
using Edm.DocumentGenerators.Domain.Entities.Documents;
using Edm.DocumentGenerators.GenericSubdomain;

using MediatR;

namespace Edm.DocumentGenerators.Application.Tech.Queries.GetAllDocumentStatuses;

internal sealed class GetAllDocumentStatusesTechQueryInternalHandler(DocumentsFacade documentsFacade)
    : IRequestHandler<GetAllDocumentStatusesTechQueryInternal, GetAllDocumentStatusesTechQueryResponseInternal>
{
    public async Task<GetAllDocumentStatusesTechQueryResponseInternal> Handle(GetAllDocumentStatusesTechQueryInternal request, CancellationToken cancellationToken)
    {
        Id<Document> documentId = IdConverterFrom<Document>.FromString(request.DocumentId);

        Document document = await documentsFacade.GetRequired(documentId, false, cancellationToken);

        DocumentStatusInternal[] statuses = document.StatusStateMachine.Transitions
            .SelectMany(t => new[] { t.From, t.To })
            .DistinctBy(s => s.Id)
            .Select(DocumentStatusInternalConverter.FromDomain)
            .ToArray();

        var result = new GetAllDocumentStatusesTechQueryResponseInternal(statuses);

        return result;
    }
}
