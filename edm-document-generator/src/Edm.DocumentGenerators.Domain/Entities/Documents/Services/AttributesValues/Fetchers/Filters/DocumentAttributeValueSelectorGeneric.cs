using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions.Rpc.BusinessLogic;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.AttributesValues.Fetchers.Filters;

public abstract class DocumentAttributeValueSelectorGeneric<TAttributeValue, TAttribute, TValue>
    : IDocumentAttributeValueSelector<TValue>
    where TAttributeValue : DocumentAttributeValueGeneric<TValue>
{
    public TValue[]? GetAllValues(DocumentAttributeValue attributeValue)
    {
        if (!IsAttributeValueMatched(attributeValue))
        {
            return null;
        }

        if (attributeValue.Attribute is not TAttribute attribute)
        {
            throw new UnsupportedTypeArgumentException<TAttribute>(attributeValue.Attribute);
        }

        if (!TypeIsMatched(attribute))
        {
            return null;
        }

        if (attributeValue is not TAttributeValue typedAttributeValue)
        {
            throw new UnsupportedTypeArgumentException<TAttributeValue>(attributeValue);
        }

        TValue[] result = typedAttributeValue.Values;

        return result;
    }

    public TValue[]? GetSingleValueOrNull(DocumentAttributeValue attributeValue)
    {
        TValue[]? result = GetAllValues(attributeValue);

        if (result is null)
        {
            return null;
        }

        if (result.Length > 1)
        {
            throw new BusinessLogicApplicationException($"There should be no or one value, but {result.Length} found (selector: {this}).");
        }

        return result;
    }

    public TValue[]? GetSingleValue(DocumentAttributeValue attributeValue)
    {
        TValue[]? result = GetAllValues(attributeValue);

        if (result is null)
        {
            return null;
        }

        if (result.Length != 1)
        {
            throw new BusinessLogicApplicationException($"There should be exactly one value, but {result.Length} found (selector: {this}).");
        }

        return result;
    }

    protected virtual bool TypeIsMatched(TAttribute attribute)
    {
        return true;
    }

    protected abstract bool IsAttributeValueMatched(DocumentAttributeValue attributeValue);
}
