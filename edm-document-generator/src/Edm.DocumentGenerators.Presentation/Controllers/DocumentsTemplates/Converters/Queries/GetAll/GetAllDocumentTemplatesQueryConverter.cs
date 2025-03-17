using Edm.DocumentGenerators.Application.DocumentTemplates.Queries.GetAll.Contracts;
using Edm.DocumentGenerators.Application.DocumentTemplates.Queries.GetAll.Contracts.QueryParams;
using Edm.DocumentGenerators.Domain;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.Presentation.Abstractions;
using Edm.DocumentGenerators.Presentation.Controllers.DocumentsTemplates.Converters.Queries.GetAll.Contracts.QueryParams;

namespace Edm.DocumentGenerators.Presentation.Controllers.DocumentsTemplates.Converters.Queries.GetAll;

internal static class GetAllDocumentTemplatesQueryConverter
{
    internal static GetAllDocumentTemplatesQueryInternal ToInternal(GetAllDocumentTemplatesQuery request)
    {
        GetAllDocumentsTemplatesQueryParamsInternal? queryParams =
            NullableConverter.Convert(request.QueryParams, GetAllDocumentsTemplatesQueryParamsDtoConverter.ToInternal);

        string domainId = DomainIdHelper.GetDomainIdOrSetDefault(request.DomainId);
        var result = new GetAllDocumentTemplatesQueryInternal(domainId, queryParams);

        return result;
    }
}
