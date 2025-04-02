using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters.Services.PendingApprovalParticipantAttributes.Detectors.
    Helpers;

internal static class PendingApprovalParticipantAttributesChangeDetector
{
    internal static bool HasChanged(DocumentAttribute[] updatedAttributes, DocumentAttribute[] originalAttributes)
    {
        if (updatedAttributes.Length != originalAttributes.Length)
        {
            return true;
        }

        Dictionary<Id<DocumentAttribute>, DocumentAttribute> originalAttributesById = originalAttributes.ToDictionary(a => a.Id);

        foreach (DocumentAttribute updatedAttribute in updatedAttributes)
        {
            DocumentAttribute? originalAttribute = originalAttributesById.GetValueOrDefault(updatedAttribute.Id);

            if (HasChanged(updatedAttribute, originalAttribute))
            {
                return true;
            }
        }

        return false;
    }

    private static bool HasChanged(DocumentAttribute updatedAttribute, DocumentAttribute? originalAttribute)
    {
        if (originalAttribute is null)
        {
            return true;
        }

        if (originalAttribute.DisplayName != updatedAttribute.DisplayName)
        {
            return true;
        }

        return false;
    }
}
