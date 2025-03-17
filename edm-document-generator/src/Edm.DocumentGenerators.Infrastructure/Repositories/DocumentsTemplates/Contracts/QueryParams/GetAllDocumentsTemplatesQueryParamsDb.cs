namespace Edm.DocumentGenerators.Infrastructure.Repositories.DocumentsTemplates.Contracts.QueryParams;

internal sealed class GetAllDocumentsTemplatesQueryParamsDb
{
    internal GetAllDocumentsTemplatesQueryParamsDb(string? query, int limit, int skip)
    {
        Query = query;
        Limit = limit;
        Skip = skip;
    }

    internal string? Query { get; }
    internal int Limit { get; }
    internal int Skip { get; }
}
