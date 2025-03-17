using Edm.Document.Searcher.Application.Documents.Events.ApprovalWorkflows.ParticipantsChanged.Contracts;
using Edm.Document.Searcher.Application.Documents.Services.Updaters;
using Edm.Document.Searcher.Domain.Documents;
using Edm.Document.Searcher.Domain.Documents.ValueObjects;
using Edm.Document.Searcher.GenericSubdomain;
using Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments;

using JetBrains.Annotations;

using MediatR;

using Microsoft.Extensions.Logging;

namespace Edm.Document.Searcher.Application.Documents.Events.ApprovalWorkflows.ParticipantsChanged;

[UsedImplicitly]
internal sealed class ParticipantsChangedEntitiesApprovalWorkflowEventInternalHandler(
    ISearchDocumentsRepository searchDocuments,
    SearchDocumentUpdater updater) : IRequestHandler<ParticipantsChangedEntitiesApprovalWorkflowEventInternal>
{
    public async Task Handle(ParticipantsChangedEntitiesApprovalWorkflowEventInternal request, CancellationToken cancellationToken)
    {
        Id<SearchDocument> documentId = IdConverterFrom<SearchDocument>.From(request.DocumentId);

        var domainId = DomainId.Parse(request.DomainId);

        var originalDocument = await searchDocuments.GetRequired(domainId, documentId, cancellationToken);

        var updatedDocument = await updater.Update(documentId, originalDocument, cancellationToken);

        await searchDocuments.Upsert(updatedDocument, cancellationToken);
    }
}
