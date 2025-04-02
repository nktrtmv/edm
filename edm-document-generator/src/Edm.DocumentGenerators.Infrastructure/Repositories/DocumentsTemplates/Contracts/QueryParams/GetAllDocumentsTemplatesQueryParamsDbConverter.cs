using Edm.DocumentGenerators.Infrastructure.Abstractions.Repositories.DocumentsTemplates.Contracts.QueryParams;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.DocumentsTemplates.Contracts.QueryParams;

internal static class GetAllDocumentsTemplatesQueryParamsDbConverter
{
    internal static GetAllDocumentsTemplatesQueryParamsDb FromDomain(GetAllDocumentsTemplatesQueryParams queryParams)
    {
        var result = new GetAllDocumentsTemplatesQueryParamsDb(queryParams.Query, queryParams.Limit, queryParams.Skip);

        return result;
    }
}
