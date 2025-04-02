using Edm.Document.Classifier.Domain;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Values;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Values.CustomReferenceValue;

namespace Edm.Document.Classifier.Application.DocumentReferences.Values.Queries.SearchValues.Contracts.Values;

internal static class DocumentReferenceValueInternalConverter
{
    internal static DocumentReferenceValueInternal FromDomain(DocumentReferenceValue value)
    {
        var result = new DocumentReferenceValueInternal(
            value.Id,
            value.DisplayValue,
            value.DisplaySubValue,
            value.TypedReference);

        return result;
    }

    internal static DocumentReferenceValueInternal FromDomain(ReferenceValue value)
    {
        string displaySubValue = string.IsNullOrWhiteSpace(value.DisplaySubValue) ? string.Empty : value.DisplaySubValue;

        var result = new DocumentReferenceValueInternal(
            value.Id.Value,
            value.DisplayValue,
            displaySubValue,
            EmptyReference.Instance);

        return result;
    }
}
