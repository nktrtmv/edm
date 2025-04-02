using Edm.Document.Searcher.Application.Documents.Events.ApprovalWorkflows.StageChanged.Contracts;
using Edm.Document.Searcher.Application.Documents.Services.Updaters;
using Edm.Document.Searcher.Domain.Documents;
using Edm.Document.Searcher.Domain.Documents.ValueObjects;
using Edm.Document.Searcher.GenericSubdomain;
using Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments;

using JetBrains.Annotations;

using MediatR;

namespace Edm.Document.Searcher.Application.Documents.Events.ApprovalWorkflows.StageChanged;

[UsedImplicitly]
internal sealed class StageChangedEntitiesApprovalWorkflowEventInternalHandler(
    ISearchDocumentsRepository searchDocuments,
    SearchDocumentUpdater updater) : IRequestHandler<StageChangedEntitiesApprovalWorkflowEventInternal>
{
    public async Task Handle(StageChangedEntitiesApprovalWorkflowEventInternal request, CancellationToken cancellationToken)
    {
        var documentId = IdConverterFrom<SearchDocument>.From(request.DocumentId);

        var domainId = DomainId.Parse(request.DomainId);

        var originalDocument = await searchDocuments.GetRequired(domainId, documentId, cancellationToken);

        var updatedDocument = await updater.Update(documentId, originalDocument, cancellationToken);

        await searchDocuments.Upsert(updatedDocument, cancellationToken);
    }
}
