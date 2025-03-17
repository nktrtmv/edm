using Edm.Document.Searcher.Application.Documents.Events.DocumentGenerators.DocumentChanged.Contracts;
using Edm.Document.Searcher.Application.Documents.Services.Updaters;
using Edm.Document.Searcher.Domain.Documents;
using Edm.Document.Searcher.Domain.Documents.ValueObjects;
using Edm.Document.Searcher.GenericSubdomain;
using Edm.Document.Searcher.Infrastructure.Abstractions;
using Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments;

using JetBrains.Annotations;

using MediatR;

namespace Edm.Document.Searcher.Application.Documents.Events.DocumentGenerators.DocumentChanged;

[UsedImplicitly]
internal sealed class DocumentChangedDocumentGeneratorEventInternalHandler(
    ISearchDocumentsRepository documentsRepository,
    SearchDocumentUpdater updater,
    ISearcherEventsProducer searcherEventsProducer) : IRequestHandler<DocumentChangedDocumentGeneratorEventInternal>
{
    public async Task Handle(DocumentChangedDocumentGeneratorEventInternal request, CancellationToken cancellationToken)
    {
        var documentId = IdConverterFrom<SearchDocument>.From(request.DocumentId);

        var domainId = DomainId.Parse(request.DomainId);

        var originalDocument = await documentsRepository.Get(domainId, documentId, cancellationToken);

        var updatedDocument = await updater.Update(documentId, originalDocument, cancellationToken);

        await documentsRepository.Upsert(updatedDocument, cancellationToken);

        await searcherEventsProducer.ProduceDocumentUpdated(domainId, documentId, cancellationToken);
    }
}
