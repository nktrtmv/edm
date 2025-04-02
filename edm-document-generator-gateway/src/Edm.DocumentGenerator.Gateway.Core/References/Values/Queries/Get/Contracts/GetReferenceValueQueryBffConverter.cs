using Edm.Document.Classifier.Presentation.Abstractions;

namespace Edm.DocumentGenerator.Gateway.Core.References.Values.Queries.Get.Contracts;

internal static class GetReferenceValueQueryBffConverter
{
    public static GetDocumentReferenceValueQuery ToDto(GetReferenceValueQueryBff request)
    {
        var result = new GetDocumentReferenceValueQuery
        {
            DomainId = request.DomainId,
            ReferenceType = request.ReferenceType,
            Id = request.Id
        };

        return result;
    }
}
