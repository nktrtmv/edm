using Edm.Document.Classifier.Application.DocumentReferences.Values.Contracts;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Values.CustomReferenceValue;

namespace Edm.Document.Classifier.Application.DocumentReferences.Values.Queries.Get.Contracts;

internal static class GetDocumentReferenceValueQueryResponseInternalConverter
{
    public static GetDocumentReferenceValueQueryResponseInternal FromDomain(ReferenceValue referenceValue)
    {
        ReferenceValueInternal value = ReferenceValueInternalConverter.FromDomain(referenceValue);

        var result = new GetDocumentReferenceValueQueryResponseInternal(value);

        return result;
    }
}
