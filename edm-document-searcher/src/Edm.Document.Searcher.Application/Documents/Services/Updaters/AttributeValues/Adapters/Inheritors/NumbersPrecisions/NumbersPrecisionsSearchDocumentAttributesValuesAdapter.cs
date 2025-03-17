using Edm.Document.Searcher.Application.Documents.Contracts.AttributesValues;
using Edm.Document.Searcher.Application.Documents.Contracts.AttributesValues.Inheritors.Numbers;
using Edm.Document.Searcher.Application.Documents.Contracts.RegistryRoles.Types.Inheritors.Numbers;
using Edm.Document.Searcher.Application.Documents.Services.Updaters.AttributeValues.Adapters.Abstractions.SynchronousSingle;
using Edm.Document.Searcher.GenericSubdomain;
using Edm.Document.Searcher.GenericSubdomain.Extensions.Types;

namespace Edm.Document.Searcher.Application.Documents.Services.Updaters.AttributeValues.Adapters.Inheritors.
    NumbersPrecisions;

internal sealed class NumbersPrecisionsSearchDocumentAttributesValuesAdapter : SynchronousSingleSearchDocumentAttributesValuesAdapter
{
    protected override SearchDocumentAttributeValueInternal Adapt(SearchDocumentAttributeValueInternal attributeValue)
    {
        if (attributeValue is not SearchDocumentNumberAttributeValueInternal numberAttributeValue)
        {
            return attributeValue;
        }

        SearchDocumentNumberRegistryRoleTypeInternal numberRegistryRoleType =
            TypeCasterTo<SearchDocumentNumberRegistryRoleTypeInternal>.CastRequired(numberAttributeValue.RegistryRole.Type);

        if (numberAttributeValue.Precision == numberRegistryRoleType.Precision)
        {
            return attributeValue;
        }

        SearchDocumentAttributeValueInternal result = Adapt(numberAttributeValue, numberRegistryRoleType.Precision);

        return result;
    }

    private static SearchDocumentAttributeValueInternal Adapt(SearchDocumentNumberAttributeValueInternal attributeValue, int precisionTo)
    {
        int precisionDifference = precisionTo - attributeValue.Precision;

        double precisionFactor = Math.Pow(10, precisionDifference);

        Number<SearchDocumentNumberAttributeValueInternal>[] values = attributeValue.Values
            .Select(v => AdjustValue(v, precisionFactor))
            .ToArray();

        var result = new SearchDocumentNumberAttributeValueInternal(
            attributeValue.RegistryRole,
            values,
            precisionTo);

        return result;
    }

    private static Number<SearchDocumentNumberAttributeValueInternal> AdjustValue(Number<SearchDocumentNumberAttributeValueInternal> value, double precisionFactor)
    {
        long originalValue = NumberConverterTo.ToLong(value);

        double adjustedValue = Math.Round(originalValue * precisionFactor);

        Number<SearchDocumentNumberAttributeValueInternal> result = NumberConverterFrom<SearchDocumentNumberAttributeValueInternal>.FromDouble(adjustedValue);

        return result;
    }
}
