using Edm.Document.Classifier.Application.DocumentReferences.Values.Queries.Get.Contracts;
using Edm.Document.Classifier.Presentation.Abstractions;
using Edm.Document.Classifier.Presentation.Controllers.References.Converters.Values.Queries.Get.Value;

namespace Edm.Document.Classifier.Presentation.Controllers.References.Converters.Values.Queries.Get;

internal static class GetDocumentReferenceValueQueryResponseConverter
{
    public static GetDocumentReferenceValueQueryResponse FromInternal(GetDocumentReferenceValueQueryResponseInternal response)
    {
        ReferenceValue value = ReferenceValueConverter.FromInternal(response.Value);

        var result = new GetDocumentReferenceValueQueryResponse
        {
            Value = value
        };

        return result;
    }
}
