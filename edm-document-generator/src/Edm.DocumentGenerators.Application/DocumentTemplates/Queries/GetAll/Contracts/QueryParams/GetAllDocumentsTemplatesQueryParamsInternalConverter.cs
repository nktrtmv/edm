using Edm.DocumentGenerators.Infrastructure.Abstractions.Repositories.DocumentsTemplates.Contracts.QueryParams;
using Edm.DocumentGenerators.Infrastructure.Abstractions.Repositories.DocumentsTemplates.Contracts.QueryParams.Factories;

namespace Edm.DocumentGenerators.Application.DocumentTemplates.Queries.GetAll.Contracts.QueryParams;

internal static class GetAllDocumentsTemplatesQueryParamsInternalConverter
{
    internal static GetAllDocumentsTemplatesQueryParams ToDomain(GetAllDocumentsTemplatesQueryParamsInternal? queryParams)
    {
        if (queryParams is null)
        {
            return GetAllDocumentsTemplatesQueryParams.Instance;
        }

        GetAllDocumentsTemplatesQueryParams result = GetAllDocumentsTemplatesQueryParamsFactory.CreateFrom(queryParams.Query, queryParams.Limit, queryParams.Skip);

        return result;
    }
}
