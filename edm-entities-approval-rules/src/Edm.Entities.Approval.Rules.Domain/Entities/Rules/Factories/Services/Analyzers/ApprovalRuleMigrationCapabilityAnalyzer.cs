using Edm.Entities.Approval.Rules.Domain.Entities.Rules.Factories.Services.Analyzers.Collectors.AttributesIds.Graphs;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules.Factories.Services.Analyzers.Collectors.AttributesIds.Groups;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules.Factories.Services.Analyzers.Detectors.AttributesCompatibility;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes;

namespace Edm.Entities.Approval.Rules.Domain.Entities.Rules.Factories.Services.Analyzers;

public static class ApprovalRuleMigrationCapabilityAnalyzer
{
    public static bool IsMigrationPossible(ApprovalRule originalRule, EntityType proposedEntityType)
    {
        bool result = IsGraphsMigrationPossible(originalRule, proposedEntityType) && IsGroupsMigrationPossible(originalRule, proposedEntityType);

        return result;
    }

    private static bool IsGraphsMigrationPossible(ApprovalRule originalRule, EntityType proposedEntityType)
    {
        HashSet<int> originalGraphsAttributesIds = ApprovalGraphsUsedAttributesIdsCollector.Collect(originalRule.Graphs);

        bool originalGraphsAttributesAreCompatibleWithProposedEntityTypeAttributes =
            EntitiesTypesAttributesCompatibilityDetector.AreCompatible(originalGraphsAttributesIds, originalRule.EntityType, proposedEntityType);

        return originalGraphsAttributesAreCompatibleWithProposedEntityTypeAttributes;
    }

    private static bool IsGroupsMigrationPossible(ApprovalRule originalRule, EntityType proposedEntityType)
    {
        HashSet<int> originalGroupsAttributesIds = ApprovalGroupsAttributesIdsCollector.Collect(originalRule.Groups);

        bool originalGroupsAttributesAreCompatibleWithProposedEntityTypeAttributes =
            EntitiesTypesAttributesCompatibilityDetector.AreCompatible(originalGroupsAttributesIds, originalRule.EntityType, proposedEntityType);

        return originalGroupsAttributesAreCompatibleWithProposedEntityTypeAttributes;
    }
}
