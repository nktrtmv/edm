using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Attributes;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Attributes.Inheritors.Number;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Attributes.Inheritors.Reference;

namespace Edm.Entities.Approval.Rules.Domain.Entities.Rules.Factories.Services.Analyzers.Detectors.AttributesCompatibility;

internal static class EntitiesTypesAttributesCompatibilityDetector
{
    internal static bool AreCompatible(HashSet<int> attributesIds, EntityType originalEntityType, EntityType targetEntityType)
    {
        EntityTypeAttribute[] originalAttributes = originalEntityType.Attributes
            .Where(a => attributesIds.Contains(a.Data.Id))
            .ToArray();

        EntityTypeAttribute[] targetAttributes = targetEntityType.Attributes;

        bool result = AreCompatible(originalAttributes, targetAttributes);

        return result;
    }

    private static bool AreCompatible(EntityTypeAttribute[] originalAttributes, EntityTypeAttribute[] targetAttributes)
    {
        foreach (EntityTypeAttribute originalAttribute in originalAttributes)
        {
            EntityTypeAttribute? targetAttribute = targetAttributes.SingleOrDefault(a => a.Data.Id == originalAttribute.Data.Id);

            if (targetAttribute is null)
            {
                return false;
            }

            bool attributesAreCompatible = AreCompatible(originalAttribute, targetAttribute);

            if (!attributesAreCompatible)
            {
                return false;
            }
        }

        return true;
    }

    private static bool AreCompatible(EntityTypeAttribute originalAttribute, EntityTypeAttribute targetAttribute)
    {
        bool attributesAreOfTheSameType = originalAttribute.GetType() == targetAttribute.GetType();

        if (!attributesAreOfTheSameType)
        {
            return false;
        }

        bool result = (originalAttribute, targetAttribute) switch
        {
            (EntityTypeReferenceAttribute originalReference, EntityTypeReferenceAttribute targetReference)
                => ReferenceAreCompatible(originalReference, targetReference),

            (EntityTypeNumberAttribute originalNumber, EntityTypeNumberAttribute targetNumber)
                => NumberAreCompatible(originalNumber, targetNumber),

            _ => true
        };

        return result;
    }

    private static bool ReferenceAreCompatible(EntityTypeReferenceAttribute originalReference, EntityTypeReferenceAttribute targetReference)
    {
        bool attributesOfTheSameReferenceTypeId = originalReference.ReferenceTypeId == targetReference.ReferenceTypeId;

        if (!attributesOfTheSameReferenceTypeId)
        {
            return false;
        }

        return true;
    }

    private static bool NumberAreCompatible(EntityTypeNumberAttribute originalNumber, EntityTypeNumberAttribute targetNumber)
    {
        bool attributesOfTheSamePrecision = originalNumber.Precision == targetNumber.Precision;

        if (!attributesOfTheSamePrecision)
        {
            return false;
        }

        return true;
    }
}
