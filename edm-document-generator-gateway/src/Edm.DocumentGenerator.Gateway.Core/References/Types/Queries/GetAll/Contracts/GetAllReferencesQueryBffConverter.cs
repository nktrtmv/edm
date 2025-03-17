using Edm.Document.Classifier.Presentation.Abstractions;

namespace Edm.DocumentGenerator.Gateway.Core.References.Types.Queries.GetAll.Contracts;

public static class GetAllReferencesQueryBffConverter
{
    public static GetAllDocumentReferenceTypesQuery ToDto(GetAllReferencesQueryBff request)
    {
        var result = new GetAllDocumentReferenceTypesQuery
        {
            DomainId = request.DomainId,
            Search = request.Query,
            Skip = request.Skip,
            Limit = request.Limit
        };

        return result;
    }
}
