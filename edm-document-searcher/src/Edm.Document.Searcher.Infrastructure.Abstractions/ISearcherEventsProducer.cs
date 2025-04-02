using Edm.Document.Searcher.Domain.Documents;
using Edm.Document.Searcher.Domain.Documents.ValueObjects;
using Edm.Document.Searcher.GenericSubdomain;

namespace Edm.Document.Searcher.Infrastructure.Abstractions;

public interface ISearcherEventsProducer
{
    Task ProduceDocumentUpdated(DomainId domainId, Id<SearchDocument> documentId, CancellationToken cancellationToken);
}
