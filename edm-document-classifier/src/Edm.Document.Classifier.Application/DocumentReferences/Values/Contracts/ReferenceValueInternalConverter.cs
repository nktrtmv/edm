using Edm.Document.Classifier.Application.DocumentReferences.Values.Queries.SearchValues.Contracts.Values;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.CustomReferences;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Values.CustomReferenceValue;
using Edm.Document.Classifier.Domain.Entities.Markers;
using Edm.Document.Classifier.GenericSubdomain;
using Edm.Document.Classifier.GenericSubdomain.Tokens.Concurrency;

namespace Edm.Document.Classifier.Application.DocumentReferences.Values.Contracts;

internal static class ReferenceValueInternalConverter
{
    public static ReferenceValueInternal FromDomain(ReferenceValue referenceValue)
    {
        Id<ReferenceValueInternal> id = IdConverterFrom<ReferenceValueInternal>.From(referenceValue.Id);

        ConcurrencyToken<ReferenceValueInternal> concurrencyToken = ConcurrencyTokenConverterFrom<ReferenceValueInternal>.From(referenceValue.ConcurrencyToken);

        var result = new ReferenceValueInternal(
            id,
            referenceValue.DisplayValue,
            referenceValue.DisplaySubValue,
            referenceValue.IsHidden,
            concurrencyToken);

        return result;
    }

    public static ReferenceValue ToDomain(DocumentReferenceValueInternal referenceValue, Id<User> currentUserId, Id<ReferenceType> referenceTypeId)
    {
        Id<ReferenceValue> id = IdConverterFrom<ReferenceValue>.FromString(referenceValue.Id);

        var concurrencyToken = ConcurrencyToken<ReferenceValue>.Empty;

        UtcDateTime<DateTime> currentDateTime = UtcDateTime<DateTime>.Now;

        var result = new ReferenceValue(
            referenceTypeId,
            id,
            referenceValue.DisplayValue,
            referenceValue.DisplaySubValue,
            false,
            currentUserId,
            currentUserId,
            currentDateTime,
            currentDateTime,
            concurrencyToken);

        return result;
    }
}
