using Edm.Document.Classifier.Application.DocumentReferences.Types.Queries.Get.Contracts;
using Edm.Document.Classifier.Presentation.Abstractions;
using Edm.Document.Classifier.Presentation.Controllers.References.Converters.Types.Queries.Get.DocumentReferenceType;

namespace Edm.Document.Classifier.Presentation.Controllers.References.Converters.Types.Queries.Get;

internal static class GetDocumentReferenceTypeQueryResponseConverter
{
    public static GetDocumentReferenceTypeQueryResponse FromInternal(GetDocumentReferenceTypeQueryResponseInternal response)
    {
        GetDocumentReferenceType reference = GetDocumentReferenceTypeConverter.FromInternal(response.ReferenceType);

        var result = new GetDocumentReferenceTypeQueryResponse
        {
            Reference = reference
        };

        return result;
    }
}
