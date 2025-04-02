namespace Edm.Document.Searcher.Infrastructure.Repositories.Documents.Contracts.Queries.Search;

internal sealed class SearchDocumentsQueryDb
{
    public SearchDocumentsQueryDb(string domainId, string filters, string sortParameters, int limit, int skip)
    {
        DomainId = domainId;
        Filters = filters;
        SortParameters = sortParameters;
        Limit = limit;
        Skip = skip;
    }

    internal string DomainId { get; }
    internal string Filters { get; }
    internal string SortParameters { get; }
    internal int Limit { get; }
    internal int Skip { get; }
}
