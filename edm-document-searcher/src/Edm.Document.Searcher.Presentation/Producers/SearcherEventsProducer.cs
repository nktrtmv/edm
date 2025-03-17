using Edm.Document.Searcher.Domain.Documents;
using Edm.Document.Searcher.Domain.Documents.ValueObjects;
using Edm.Document.Searcher.GenericSubdomain;
using Edm.Document.Searcher.GenericSubdomain.Tracing;
using Edm.Document.Searcher.Infrastructure.Abstractions;
using Edm.Document.Searcher.Presentation.Abstractions;

using Google.Protobuf;

using KafkaFlow;

namespace Edm.Document.Searcher.Presentation.Producers;

public sealed class SearcherEventsProducer(IMessageProducer<SearcherEventsProducer> producer, ILogger<SearcherEventsProducer> logger) : ISearcherEventsProducer
{
    public async Task ProduceDocumentUpdated(DomainId domainId, Id<SearchDocument> documentId, CancellationToken cancellationToken)
    {
        var key = new EdmDocumentSearcherEventsKeyDto { Key = documentId.Value };
        var value = new EdmDocumentSearcherEventsValueDto
        {
            Event = new SearcherEventDto
            {
                DocumentUpdated = new DocumentUpdatedEventDto
                {
                    DomainId = domainId.Value,
                    DocumentId = documentId.Value
                }
            }
        };

        var byteKey = key.ToByteArray();
        var byteValue = value.ToByteArray();

        await TracingFacility.TraceKafkaProducer(
            logger,
            nameof(ProduceDocumentUpdated),
            key,
            value,
            () => producer.ProduceAsync(byteKey, byteValue));
    }
}
