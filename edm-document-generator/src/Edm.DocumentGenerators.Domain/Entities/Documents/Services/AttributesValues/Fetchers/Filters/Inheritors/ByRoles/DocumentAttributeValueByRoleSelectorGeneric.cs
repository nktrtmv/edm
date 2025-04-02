using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.ValueObjects.DocumentsRoles;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.AttributesValues.Fetchers.Filters.Inheritors.ByRoles;

public abstract class DocumentAttributeValueByRoleSelectorGeneric<TAttributeValue, TAttribute, TValue>(DocumentAttributeDocumentRole role, params string[] displayNames)
    : DocumentAttributeValueSelectorGeneric<TAttributeValue, TAttribute, TValue>
    where TAttributeValue : DocumentAttributeValueGeneric<TValue>
{
    protected override bool IsAttributeValueMatched(DocumentAttributeValue attributeValue)
    {
        if (attributeValue.Attribute.Data.DocumentsRoles.Contains((int)role))
        {
            return true;
        }

        string displayName = attributeValue.Attribute.Data.DisplayName;

        if (displayNames.Contains(displayName, StringComparer.OrdinalIgnoreCase))
        {
            return true;
        }

        return false;
    }

    public override string ToString()
    {
        string names = string.Join(", ", displayNames);

        var result = $"role: {role}, display names: '{names}'";

        return result;
    }
}
