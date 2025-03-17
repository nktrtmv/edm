using Edm.DocumentGenerators.Application.Contracts.Markers;
using Edm.DocumentGenerators.Application.Documents.Commands.UpdateBatch.DocumentClerk.Contracts;
using Edm.DocumentGenerators.Application.Documents.Services;
using Edm.DocumentGenerators.Domain;
using Edm.DocumentGenerators.Domain.Entities.Documents;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Parameters;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Updates.Documents.Generator;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects;
using Edm.DocumentGenerators.Domain.Markers;
using Edm.DocumentGenerators.GenericSubdomain;

using MediatR;

using Microsoft.Extensions.Logging;

namespace Edm.DocumentGenerators.Application.Documents.Commands.UpdateBatch.DocumentClerk;

internal sealed class DocumentClerkBatchUpdateCommandInternalHandler(
    IRoleAdapter roleAdapter,
    DocumentsFacade documentsFacade,
    ILogger<DocumentClerkBatchUpdateCommandInternalHandler> logger)
    : IRequestHandler<DocumentClerkBatchUpdateCommandInternal, DocumentClerkBatchUpdateCommandInternalResponse>
{
    public async Task<DocumentClerkBatchUpdateCommandInternalResponse> Handle(DocumentClerkBatchUpdateCommandInternal request, CancellationToken cancellationToken)
    {
        DomainId domainId = DomainId.Parse(request.DomainId);
        Id<User> currentUserId = IdConverterFrom<User>.From(request.CurrentUserId);

        var uncompletedDocuments = new List<Id<Document>>();

        foreach (Id<DocumentInternal> requestDocumentId in request.DocumentIds)
        {
            Id<Document> documentId = IdConverterFrom<Document>.From(requestDocumentId);

            Document? document = await documentsFacade.GetRequired(domainId, documentId, cancellationToken);

            DocumentUpdateParameters? parameters = DocumentClerkBatchUpdateCommandInternalConverter.ToDomain(document, request.NewClerkId);

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
        }

        DocumentClerkBatchUpdateCommandInternalResponse? result = DocumentClerkBatchUpdateCommandInternalResponseConverter.ToInternal(uncompletedDocuments);

        return result;
    }
}
