using Edm.Document.Searcher.Domain.Documents;
using Edm.Document.Searcher.Domain.Documents.ValueObjects;
using Edm.Document.Searcher.GenericSubdomain;
using Edm.Document.Searcher.GenericSubdomain.Tokens.Concurrency;
using Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments.Contracts.Queries.Get;
using Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments.Contracts.Queries.Search;

namespace Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments;

public interface ISearchDocumentsRepository
{
    Task<ConcurrencyToken<SearchDocument>> Upsert(SearchDocument document, CancellationToken cancellationToken);
    Task<Id<SearchDocument>[]> Search(SearchDocumentsQuery query, CancellationToken cancellationToken);
    Task<SearchDocument[]> Get(GetDocumentsQuery query, CancellationToken cancellationToken);
    Task<SearchDocument?> Get(DomainId domainId, Id<SearchDocument> documentId, CancellationToken cancellationToken);
    Task<SearchDocument> GetRequired(DomainId domainId, Id<SearchDocument> documentId, CancellationToken cancellationToken);
    Task DeleteByIds(DomainId domainId, HashSet<Id<SearchDocument>> documentIds, CancellationToken cancellationToken);
}
