using Edm.DocumentGenerators.Domain.Entities.Documents.Services.AttributesValues.Fetchers.Filters;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Services.Collectors;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions.Rpc.BusinessLogic;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.AttributesValues.Fetchers;

public sealed class DocumentAttributesValuesFetcher
{
    public DocumentAttributesValuesFetcher(DocumentAttributeValue[] attributesValues)
    {
        AttributesValues = attributesValues;
    }

    private DocumentAttributeValue[] AttributesValues { get; }

    public TValue[] FetchManyAttributesWithManyValues<TValue>(IDocumentAttributeValueSelector<TValue> selector)
    {
        TValue[] result = FetchAllAttributes(selector.GetAllValues)
            .SelectMany(v => v)
            .ToArray();

        return result;
    }

    public TValue[] FetchSingleAttributeOrNullWithAllValues<TValue>(IDocumentAttributeValueSelector<TValue> selector)
    {
        TValue[][] attributesValues = FetchAllAttributes(selector.GetAllValues);

        if (attributesValues.Length == 0)
        {
            return Array.Empty<TValue>();
        }

        if (attributesValues.Length > 1)
        {
            throw new BusinessLogicApplicationException($"There shall be at most 1 attribute, but {attributesValues.Length} found (value selector: {selector}).");
        }

        TValue[] result = attributesValues.Single();

        return result;
    }

    public TValue? FetchSingleAttributeOrNullWithSingleValueOrNull<TValue>(IDocumentAttributeValueSelector<TValue> selector)
    {
        TValue[][] attributesValues = FetchAllAttributes(selector.GetSingleValueOrNull);

        if (attributesValues.Length == 0)
        {
            return default;
        }

        if (attributesValues.Length > 1)
        {
            throw new BusinessLogicApplicationException($"There shall be at most 1 attribute, but {attributesValues.Length} found (value selector: {selector}).");
        }

        TValue[] values = attributesValues.Single();

        if (values.Length == 0)
        {
            return default;
        }

        TValue result = values.Single();

        return result;
    }

    public TValue? FetchSingleAttributeWithSingleValueOrNull<TValue>(IDocumentAttributeValueSelector<TValue> selector)
    {
        TValue[][] attributesValues = FetchAllAttributes(selector.GetSingleValueOrNull);

        if (attributesValues.Length != 1)
        {
            throw new BusinessLogicApplicationException($"There shall be single attribute, but {attributesValues.Length} found (value selector: {selector}).");
        }

        TValue[] values = attributesValues.Single();

        if (values.Length == 0)
        {
            return default;
        }

        TValue result = values.Single();

        return result;
    }

    public TValue FetchSingleAttributeWithSingleValue<TValue>(IDocumentAttributeValueSelector<TValue> selector)
    {
        TValue[][] attributesValues = FetchAllAttributes(selector.GetSingleValue);

        if (attributesValues.Length != 1)
        {
            throw new BusinessLogicApplicationException($"There shall be single attribute, but {attributesValues.Length} found (value selector: {selector}).");
        }

        TValue[] values = attributesValues.Single();

        TValue result = values.Single();

        return result;
    }

    private TValue[][] FetchAllAttributes<TValue>(Func<DocumentAttributeValue, TValue[]?> selector)
    {
        TValue[][] result = DocumentAttributesValuesCollector.Collect(AttributesValues)
            .Select(selector)
            .Where(v => v is not null)
            .Select(v => v!)
            .ToArray();

        return result;
    }
}
