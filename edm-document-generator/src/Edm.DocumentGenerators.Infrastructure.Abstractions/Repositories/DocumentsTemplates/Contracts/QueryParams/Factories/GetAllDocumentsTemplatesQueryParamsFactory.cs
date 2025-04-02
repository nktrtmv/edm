namespace Edm.DocumentGenerators.Infrastructure.Abstractions.Repositories.DocumentsTemplates.Contracts.QueryParams.Factories;

public static class GetAllDocumentsTemplatesQueryParamsFactory
{
    public static GetAllDocumentsTemplatesQueryParams CreateFrom(string? query, int limit, int skip)
    {
        var result = new GetAllDocumentsTemplatesQueryParams(query, limit, skip);

        return result;
    }
}
