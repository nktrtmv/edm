using Edm.Document.Classifier.Presentation.Abstractions;

namespace Edm.DocumentGenerator.Gateway.Core.References.Values.Queries.GetAll.Contracts;

internal static class GetAllReferenceValuesQueryBffConverter
{
    public static GetAllDocumentReferenceValuesQuery ToDto(GetAllReferenceValuesQueryBff request)
    {
        var result = new GetAllDocumentReferenceValuesQuery
        {
            DomainId = request.DomainId,
            ReferenceType = request.ReferenceType,
            Search = request.Query,
            Skip = request.Skip,
            Limit = request.Limit
        };

        return result;
    }
}
