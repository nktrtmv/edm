using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.AttributesValues.Fetchers.Filters.Inheritors.ByIds;

public abstract class DocumentAttributeValueByIdSelectorGeneric<TAttributeValue, TAttribute, TValue>
    : DocumentAttributeValueSelectorGeneric<TAttributeValue, TAttribute, TValue>
    where TAttributeValue : DocumentAttributeValueGeneric<TValue>
{
    protected DocumentAttributeValueByIdSelectorGeneric(Id<DocumentAttribute> id)
    {
        Id = id;
    }

    private Id<DocumentAttribute> Id { get; }

    protected override bool IsAttributeValueMatched(DocumentAttributeValue attributeValue)
    {
        if (attributeValue.Attribute.Id == Id)
        {
            return true;
        }

        return false;
    }

    public override string ToString()
    {
        var id = IdConverterTo.ToString(Id);

        var result = $"id: {id}";

        return result;
    }
}
