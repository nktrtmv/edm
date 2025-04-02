namespace Edm.Document.Searcher.Infrastructure.Repositories.Documents.Contracts.Queries.Get;

internal sealed record GetDocumentsQueryDb(
    string DomainId,
    string Filters,
    string SortParameters,
    string[] DocumentsIds,
    int Limit,
    int Skip);
