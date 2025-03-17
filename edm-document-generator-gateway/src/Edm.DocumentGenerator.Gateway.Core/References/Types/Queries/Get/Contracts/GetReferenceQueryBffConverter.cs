using Edm.Document.Classifier.Presentation.Abstractions;

namespace Edm.DocumentGenerator.Gateway.Core.References.Types.Queries.Get.Contracts;

internal static class GetReferenceQueryBffConverter
{
    public static GetDocumentReferenceTypeQuery ToDto(GetReferenceQueryBff request)
    {
        var result = new GetDocumentReferenceTypeQuery
        {
            DomainId = request.DomainId,
            ReferenceType = request.ReferenceType
        };

        return result;
    }
}
