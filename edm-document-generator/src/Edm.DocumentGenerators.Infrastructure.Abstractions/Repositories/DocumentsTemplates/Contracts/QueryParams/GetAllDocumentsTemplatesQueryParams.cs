namespace Edm.DocumentGenerators.Infrastructure.Abstractions.Repositories.DocumentsTemplates.Contracts.QueryParams;

public sealed class GetAllDocumentsTemplatesQueryParams
{
    public static readonly GetAllDocumentsTemplatesQueryParams Instance = new GetAllDocumentsTemplatesQueryParams(null, int.MaxValue, 0);

    internal GetAllDocumentsTemplatesQueryParams(string? query, int limit, int skip)
    {
        Query = query;
        Limit = limit;
        Skip = skip;
    }

    public string? Query { get; }
    public int Limit { get; }
    public int Skip { get; }
}
