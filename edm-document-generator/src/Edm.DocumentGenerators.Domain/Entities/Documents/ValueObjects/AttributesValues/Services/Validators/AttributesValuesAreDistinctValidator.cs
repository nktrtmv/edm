using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions.Rpc.BusinessLogic;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Services.Validators;

internal static class AttributesValuesAreDistinctValidator
{
    // TODO: Make distinct on a level (tuple level).
    internal static void Validate(DocumentAttributeValue[] attributesValues)
    {
        var distinctAttributesValuesIds = new HashSet<Id<DocumentAttribute>>();

        foreach (DocumentAttributeValue attributeValue in attributesValues)
        {
            if (!distinctAttributesValuesIds.Add(attributeValue.Id))
            {
                throw new BusinessLogicApplicationException($"Attribute value with the same id ({attributeValue.Id}) has been detected.");
            }
        }
    }
}
