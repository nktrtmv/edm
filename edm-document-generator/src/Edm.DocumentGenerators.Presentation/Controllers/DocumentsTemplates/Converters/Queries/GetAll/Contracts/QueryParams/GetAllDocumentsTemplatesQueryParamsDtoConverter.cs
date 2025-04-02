using Edm.DocumentGenerators.Application.DocumentTemplates.Queries.GetAll.Contracts.QueryParams;
using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.DocumentGenerators.Presentation.Controllers.DocumentsTemplates.Converters.Queries.GetAll.Contracts.QueryParams;

internal static class GetAllDocumentsTemplatesQueryParamsDtoConverter
{
    internal static GetAllDocumentsTemplatesQueryParamsInternal ToInternal(GetAllDocumentsTemplatesQueryParamsDto queryParams)
    {
        var result = new GetAllDocumentsTemplatesQueryParamsInternal(queryParams.Query, queryParams.Limit, queryParams.Skip);

        return result;
    }
}
