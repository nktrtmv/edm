using Edm.Document.Classifier.Application.DocumentReferences.Values.Contracts;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Values.CustomReferenceValue;

namespace Edm.Document.Classifier.Application.DocumentReferences.Values.Queries.GetAll.Contracts;

internal static class GetAllDocumentReferenceValuesQueryResponseInternalConverter
{
    public static GetAllDocumentReferenceValuesQueryResponseInternal FromDomain(ReferenceValue[] referenceValues)
    {
        ReferenceValueInternal[] values = referenceValues.Select(ReferenceValueInternalConverter.FromDomain).ToArray();

        var result = new GetAllDocumentReferenceValuesQueryResponseInternal(values);

        return result;
    }
}
