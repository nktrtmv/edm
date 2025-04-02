using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Inheritors;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions.Rpc.BusinessLogic;

namespace Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters.Services.UpdateParametersValidators.Validators.Attributes;

internal static class DocumentAttributesPreserveTypeValidator
{
    internal static void Validate(DocumentAttribute[] updatedAttributes, Dictionary<Id<DocumentAttribute>, DocumentAttribute> originalAttributesById)
    {
        foreach (DocumentAttribute updatedAttribute in updatedAttributes)
        {
            DocumentAttribute? originalAttribute = originalAttributesById.GetValueOrDefault(updatedAttribute.Id);

            if (HasTypeChanged(updatedAttribute, originalAttribute))
            {
                throw new BusinessLogicApplicationException(
                    $"Attribute (id: {updatedAttribute.Id}) type should not change (before: {originalAttribute!.GetType()}, after: {updatedAttribute.GetType()}).");
            }
        }
    }

    private static bool HasTypeChanged(DocumentAttribute updatedAttribute, DocumentAttribute? originalAttribute)
    {
        if (originalAttribute is null)
        {
            return false;
        }

        if (updatedAttribute.GetType() != originalAttribute.GetType())
        {
            return true;
        }

        if (originalAttribute is DocumentReferenceAttribute originalReferenceAttribute)
        {
            var updatedReferenceAttribute = (DocumentReferenceAttribute)updatedAttribute;

            bool referenceTypeHasChanged = updatedReferenceAttribute.ReferenceType != originalReferenceAttribute.ReferenceType;

            return referenceTypeHasChanged;
        }

        return false;
    }
}
