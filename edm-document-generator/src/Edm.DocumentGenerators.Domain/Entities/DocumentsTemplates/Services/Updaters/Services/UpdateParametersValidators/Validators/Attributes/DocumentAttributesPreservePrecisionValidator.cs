using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Inheritors;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions.Rpc.BusinessLogic;

namespace Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters.Services.UpdateParametersValidators.Validators.Attributes;

internal static class DocumentAttributesPreservePrecisionValidator
{
    internal static void Validate(DocumentAttribute[] updatedAttributes, Dictionary<Id<DocumentAttribute>, DocumentAttribute> originalAttributesById)
    {
        foreach (DocumentAttribute updatedAttribute in updatedAttributes)
        {
            DocumentAttribute? originalAttribute = originalAttributesById.GetValueOrDefault(updatedAttribute.Id);

            if (HasPrecisionChanged(updatedAttribute, originalAttribute))
            {
                throw new BusinessLogicApplicationException(
                    $$"""
                      Precision should not change.
                      Id: {{updatedAttribute.Id}}
                      AttributeDisplayName: {{updatedAttribute.DisplayName}}
                      """);
            }
        }
    }

    private static bool HasPrecisionChanged(DocumentAttribute updatedAttribute, DocumentAttribute? originalAttribute)
    {
        if (originalAttribute is null)
        {
            return false;
        }

        if (updatedAttribute.GetType() != originalAttribute.GetType())
        {
            return true;
        }

        if (originalAttribute is DocumentNumberAttribute originalNumberAttribute)
        {
            var updatedNumberAttribute = (DocumentNumberAttribute)updatedAttribute;

            bool precisionHasChanged = updatedNumberAttribute.Precision != originalNumberAttribute.Precision;

            return precisionHasChanged;
        }

        return false;
    }
}
