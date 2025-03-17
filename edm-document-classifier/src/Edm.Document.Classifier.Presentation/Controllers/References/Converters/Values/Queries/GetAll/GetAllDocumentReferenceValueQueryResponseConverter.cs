using Edm.Document.Classifier.Application.DocumentReferences.Values.Queries.GetAll.Contracts;
using Edm.Document.Classifier.Presentation.Abstractions;
using Edm.Document.Classifier.Presentation.Controllers.References.Converters.Values.Queries.Get.Value;

namespace Edm.Document.Classifier.Presentation.Controllers.References.Converters.Values.Queries.GetAll;

internal static class GetAllDocumentReferenceValuesQueryResponseConverter
{
    public static GetAllDocumentReferenceValuesQueryResponse FromInternal(GetAllDocumentReferenceValuesQueryResponseInternal response)
    {
        ReferenceValue[] values = response.Values.Select(ReferenceValueConverter.FromInternal).ToArray();

        var result = new GetAllDocumentReferenceValuesQueryResponse
        {
            Values = { values }
        };

        return result;
    }
}
