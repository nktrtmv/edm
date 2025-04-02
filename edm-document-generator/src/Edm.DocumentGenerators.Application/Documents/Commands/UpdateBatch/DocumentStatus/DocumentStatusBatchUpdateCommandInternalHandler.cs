using Edm.DocumentGenerators.Application.Documents.Commands.UpdateBatch.DocumentStatus.Contracts;
using Edm.DocumentGenerators.Application.Documents.Services;
using Edm.DocumentGenerators.Domain;
using Edm.DocumentGenerators.Domain.Entities.Documents;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Parameters;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Updates.Documents.Generator;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects;
using Edm.DocumentGenerators.Domain.Markers;
using Edm.DocumentGenerators.GenericSubdomain;

using JetBrains.Annotations;

using MediatR;

using Microsoft.Extensions.Logging;

namespace Edm.DocumentGenerators.Application.Documents.Commands.UpdateBatch.DocumentStatus;

[UsedImplicitly]
internal sealed class DocumentStatusBatchUpdateCommandInternalHandler(
    IRoleAdapter roleAdapter,
    DocumentsFacade documentsFacade,
    ILogger<DocumentStatusBatchUpdateCommandInternalHandler> logger)
    : IRequestHandler<DocumentStatusBatchUpdateCommandInternal, DocumentStatusBatchUpdateCommandInternalResponse>
{
    public async Task<DocumentStatusBatchUpdateCommandInternalResponse> Handle(DocumentStatusBatchUpdateCommandInternal request, CancellationToken cancellationToken)
    {
        DomainId domainId = DomainId.Parse(request.DomainId);

        Id<User>? currentUserId = IdConverterFrom<User>.FromString(request.CurrentUserId);

        HashSet<Id<Document>> documentIds = request.DocumentIds.Select(IdConverterFrom<Document>.FromString).ToHashSet();

        IEnumerable<Task<UpdateDocumentResult>> tasks = documentIds
            .Select(
                documentId =>
                {
                    Task<UpdateDocumentResult> updateDocumentStatusTask = UpdateDocumentStatus(
                        domainId,
                        documentId,
                        request.NewStatusId,
                        currentUserId,
                        cancellationToken);

                    Task<UpdateDocumentResult> result = HandleErrors(updateDocumentStatusTask, documentId, request.NewStatusId);

                    return result;
                });

        UpdateDocumentResult[] updateResults = await Task.WhenAll(tasks);

        Id<Document>[] uncompletedDocuments = updateResults.Where(r => !r.IsProcessed).Select(r => r.DocumentId).ToArray();

        DocumentStatusBatchUpdateCommandInternalResponse? result = DocumentStatusBatchUpdateCommandInternalResponseConverter.ToInternal(uncompletedDocuments);

        return result;
    }

    private async Task<UpdateDocumentResult> UpdateDocumentStatus(
        DomainId domainId,
        Id<Document> documentId,
        string newStatusId,
        Id<User> currentUserId,
        CancellationToken cancellationToken)
    {
        Document? document = await documentsFacade.GetRequired(domainId, documentId, cancellationToken);

        DocumentUpdateParameters? parameters = DocumentStatusBatchUpdateCommandInternalConverter.ToDomain(document, newStatusId);

        var update = new DocumentGeneratorDocumentUpdate(currentUserId, parameters);

        DocumentUpdater.Update(roleAdapter, document, update);

        logger.LogInformation(
            """
            DOCUMENT GENERATOR UPDATE: 📝📝📝 {Change:l}
            Document: {Document:l}
            """,
            update,
            document);

        await documentsFacade.Upsert(document, cancellationToken);

        return new UpdateDocumentResult(documentId, true);
    }

    private async Task<UpdateDocumentResult> HandleErrors(Task<UpdateDocumentResult> task, Id<Document> documentId, string newStatusId)
    {
        UpdateDocumentResult result;

        try
        {
            result = await task;
        }
        catch (Exception e)
        {
            logger.LogError(
                e,
                """
                Error due batch change document status.
                DocumentId: {DocumentId}
                StatusId: {StatusId}
                """,
                documentId,
                newStatusId);

            return new UpdateDocumentResult(documentId, false);
        }

        return result;
    }

    private sealed record UpdateDocumentResult(Id<Document> DocumentId, bool IsProcessed);
}
