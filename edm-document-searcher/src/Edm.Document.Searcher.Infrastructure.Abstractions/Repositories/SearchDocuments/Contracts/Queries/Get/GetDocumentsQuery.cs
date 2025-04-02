using Edm.Document.Searcher.Domain.Documents.ValueObjects;
using Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments.Contracts.Contracts.Filters;
using Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments.Contracts.Contracts.SortParameters;

namespace Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments.Contracts.Queries.Get;

public sealed record GetDocumentsQuery(
    DomainId DomainId,
    SearchDocumentsQueryFilter[] Filters,
    SearchDocumentSortParameters SortParameters,
    string[] DocumentsIds,
    int Limit,
    int Skip);
