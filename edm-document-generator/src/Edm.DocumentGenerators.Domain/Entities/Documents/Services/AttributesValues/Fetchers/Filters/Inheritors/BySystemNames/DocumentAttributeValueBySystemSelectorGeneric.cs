using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.AttributesValues.Fetchers.Filters.Inheritors.BySystemNames;

public abstract class DocumentAttributeValueBySystemSelectorGeneric<TAttributeValue, TAttribute, TValue>
    : DocumentAttributeValueSelectorGeneric<TAttributeValue, TAttribute, TValue>
    where TAttributeValue : DocumentAttributeValueGeneric<TValue>
{
    protected DocumentAttributeValueBySystemSelectorGeneric(string systemName)
    {
        SystemName = systemName;
    }

    private string SystemName { get; }

    protected override bool IsAttributeValueMatched(DocumentAttributeValue attributeValue)
    {
        if (attributeValue.Attribute.SystemName?.Value.Equals(SystemName, StringComparison.OrdinalIgnoreCase) ?? false)
        {
            return true;
        }

        return false;
    }

    public override string ToString()
    {
        var result = $"SystemName: {SystemName}";

        return result;
    }
}
