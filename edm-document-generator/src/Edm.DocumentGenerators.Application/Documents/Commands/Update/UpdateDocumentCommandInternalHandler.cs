using Edm.DocumentGenerators.Application.Documents.Commands.Update.Contracts;
using Edm.DocumentGenerators.Application.Documents.Commands.Update.Contracts.Parameters;
using Edm.DocumentGenerators.Application.Documents.Services;
using Edm.DocumentGenerators.Domain;
using Edm.DocumentGenerators.Domain.Entities.Documents;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Parameters;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Updates.Documents.Generator;
using Edm.DocumentGenerators.Domain.Markers;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Tokens.Concurrency;

using JetBrains.Annotations;

using MediatR;

using Microsoft.Extensions.Logging;

namespace Edm.DocumentGenerators.Application.Documents.Commands.Update;

[UsedImplicitly]
internal class UpdateDocumentCommandInternalHandler(
    DocumentsFacade documentsFacade,
    ILogger<UpdateDocumentCommandInternalHandler> logger,
    IRoleAdapter roleAdapter) : IRequestHandler<UpdateDocumentCommandInternal>
{
    public async Task Handle(UpdateDocumentCommandInternal request, CancellationToken cancellationToken)
    {
        Id<Document>? documentId = IdConverterFrom<Document>.From(request.DocumentId);

        Document? document = await documentsFacade.GetRequired(documentId, cancellationToken);

        ConcurrencyToken<Document> concurrencyToken = ConcurrencyTokenConverterFrom<Document>.From(request.ConcurrencyToken);

        document.ConcurrencyToken.AssertEqualsTo(concurrencyToken);

        Id<User> currentUserId = IdConverterFrom<User>.From(request.CurrentUserId);

        DocumentUpdateParameters? parameters = DocumentUpdateParametersInternalConverter.ToDomain(request.Parameters, document);

        await Update(currentUserId, parameters, document, cancellationToken);
    }

    private async Task Update(Id<User> currentUserId, DocumentUpdateParameters parameters, Document document, CancellationToken cancellationToken)
    {
        var update = new DocumentGeneratorDocumentUpdate(currentUserId, parameters);

        DocumentUpdater.Update(roleAdapter, document, update);

        logger.LogInformation(
            """
            DOCUMENT GENERATOR UPDATE: 📝📝📝 {Update:l}
            Document: {Document:l}
            """,
            update,
            document);

        await documentsFacade.Upsert(document, cancellationToken);
    }
}
