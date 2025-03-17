using Edm.Document.Searcher.Domain.Documents.ValueObjects;
using Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments.Contracts.Contracts.Filters;
using Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments.Contracts.Contracts.SortParameters;

namespace Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments.Contracts.Queries.Search;

public sealed record SearchDocumentsQuery(
    DomainId DomainId,
    SearchDocumentsQueryFilter[] Filters,
    SearchDocumentSortParameters SortParameters,
    int Limit,
    int Skip);
