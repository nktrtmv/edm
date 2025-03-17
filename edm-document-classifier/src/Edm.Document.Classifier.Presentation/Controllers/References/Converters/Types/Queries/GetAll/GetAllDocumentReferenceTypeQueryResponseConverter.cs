using Edm.Document.Classifier.Application.DocumentReferences.Types.Queries.GetAll.Contracts;
using Edm.Document.Classifier.Presentation.Abstractions;
using Edm.Document.Classifier.Presentation.Controllers.References.Converters.Types.Queries.Get.DocumentReferenceType;

namespace Edm.Document.Classifier.Presentation.Controllers.References.Converters.Types.Queries.GetAll;

internal static class GetAllDocumentReferenceTypesQueryResponseConverter
{
    public static GetAllDocumentReferenceTypesQueryResponse FromInternal(GetAllDocumentReferenceTypesQueryResponseInternal response)
    {
        GetDocumentReferenceType[] references = response.ReferenceTypes.Select(GetDocumentReferenceTypeConverter.FromInternal).ToArray();

        var result = new GetAllDocumentReferenceTypesQueryResponse
        {
            References = { references }
        };

        return result;
    }
}
