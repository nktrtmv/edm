namespace Edm.DocumentGenerators.Application.DocumentTemplates.Queries.GetAll.Contracts.QueryParams;

public sealed class GetAllDocumentsTemplatesQueryParamsInternal
{
    public GetAllDocumentsTemplatesQueryParamsInternal(string? query, int limit, int skip)
    {
        Query = query;
        Limit = limit;
        Skip = skip;
    }

    internal string? Query { get; }
    internal int Limit { get; }
    internal int Skip { get; }
}
