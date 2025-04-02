using Edm.Entities.Approval.Rules.Domain.Entities.Graphs;
using Edm.Entities.Approval.Rules.Domain.Entities.Groups;
using Edm.Entities.Approval.Rules.Domain.Markers;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes;
using Edm.Entities.Approval.Rules.GenericSubdomain;
using Edm.Entities.Approval.Rules.GenericSubdomain.Audits.Domain;
using Edm.Entities.Approval.Rules.GenericSubdomain.Audits.Domain.Factories;
using Edm.Entities.Approval.Rules.GenericSubdomain.Tokens.Concurrency;

namespace Edm.Entities.Approval.Rules.Domain.Entities.Rules.Factories;

public static class ApprovalRuleFactory
{
    public static ApprovalRule CreateNew(EntityType entityType, Id<User> currentUserId)
    {
        ApprovalGraph[] graphs = [];

        ApprovalGroup[] groups = [];

        const int version = 0;
        const int originalVersion = 0;

        const bool isActive = false;

        ApprovalRule result = CreateFrom(
            entityType,
            originalVersion,
            version,
            isActive,
            graphs,
            groups,
            currentUserId,
            false);

        return result;
    }

    public static ApprovalRule CreateNewVersion(ApprovalRule rule, int originalVersion, int version, Id<User> currentUserId)
    {
        ApprovalRule result = CreateFrom(
            rule.EntityType,
            originalVersion,
            version,
            false,
            rule.Graphs,
            rule.Groups,
            currentUserId,
            rule.IsDeleted);

        return result;
    }

    public static ApprovalRule CreateFrom(ApprovalRule previousRule, EntityType entityType)
    {
        ConcurrencyToken<ApprovalRule> concurrencyToken = previousRule.ConcurrencyToken;

        ApprovalRule result = CreateFromDb(
            entityType,
            previousRule.OriginalVersion,
            previousRule.Version,
            previousRule.IsActive,
            previousRule.Graphs,
            previousRule.Groups,
            previousRule.Audit,
            concurrencyToken,
            previousRule.IsDeleted);

        return result;
    }

    private static ApprovalRule CreateFrom(
        EntityType entityType,
        int originalVersion,
        int version,
        bool isActive,
        ApprovalGraph[] graphs,
        ApprovalGroup[] groups,
        Id<User> currentUserId,
        bool isDeleted)
    {
        Audit<ApprovalRule> audit = AuditFactory<ApprovalRule>.CreateNew(currentUserId);

        var concurrencyToken = ConcurrencyToken<ApprovalRule>.Empty;

        ApprovalRule result = CreateFromDb(entityType, originalVersion, version, isActive, graphs, groups, audit, concurrencyToken, isDeleted);

        return result;
    }

    public static ApprovalRule CreateFromDb(
        EntityType entityType,
        int originalVersion,
        int version,
        bool isActive,
        ApprovalGraph[] graphs,
        ApprovalGroup[] groups,
        Audit<ApprovalRule> audit,
        ConcurrencyToken<ApprovalRule> concurrencyToken,
        bool isDeleted)
    {
        var result = new ApprovalRule(
            entityType,
            originalVersion,
            version,
            isActive,
            graphs,
            groups,
            audit,
            concurrencyToken,
            isDeleted);

        return result;
    }
}
