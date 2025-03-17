using Edm.Document.Classifier.Infrastructure.Abstractions.Repositories.DocumentReferenceTypes.Contracts.QueryParams;

namespace Edm.Document.Classifier.Infrastructure.Repositories.DocumentReferenceTypes.Contracts.QueryParams;

internal static class GetAllDocumentReferenceTypesQueryParamsDbConverter
{
    internal static GetAllDocumentReferenceTypesQueryParamsDb FromDomain(GetAllDocumentReferenceTypesQueryParams queryParams)
    {
        var result = new GetAllDocumentReferenceTypesQueryParamsDb(queryParams.Query, queryParams.Limit, queryParams.Skip, queryParams.Ids);

        return result;
    }
}
