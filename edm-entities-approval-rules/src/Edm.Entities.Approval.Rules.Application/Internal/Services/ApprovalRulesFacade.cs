using Edm.Entities.Approval.Rules.Application.Contracts.Rules.Keys;
using Edm.Entities.Approval.Rules.Application.Internal.Contracts.Markers;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules.ValueObjects.Keys;
using Edm.Entities.Approval.Rules.Domain.Markers;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Keys;
using Edm.Entities.Approval.Rules.GenericSubdomain;
using Edm.Entities.Approval.Rules.GenericSubdomain.Audits.Domain;
using Edm.Entities.Approval.Rules.GenericSubdomain.Audits.Domain.Factories;
using Edm.Entities.Approval.Rules.GenericSubdomain.Tokens.Concurrency;
using Edm.Entities.Approval.Rules.Infrastructure.Abstractions.Repositories.Rules;

namespace Edm.Entities.Approval.Rules.Application.Internal.Services;

public sealed class ApprovalRulesFacade(IApprovalRulesRepository rules)
{
    public async Task<ApprovalRule> GetRequired(
        ApprovalRuleKeyInternal approvalRuleKey,
        ConcurrencyToken<ApprovalRuleInternal> concurrencyToken,
        CancellationToken cancellationToken)
    {
        ApprovalRule rule = await GetRequired(approvalRuleKey, cancellationToken);

        ConcurrencyToken<ApprovalRule> incomingToken =
            ConcurrencyTokenConverterFrom<ApprovalRule>.From(concurrencyToken);

        rule.ConcurrencyToken.AssertEqualsTo(incomingToken);

        return rule;
    }

    public async Task<ApprovalRule> GetRequired(ApprovalRuleKeyInternal approvalRuleKey, CancellationToken cancellationToken)
    {
        ApprovalRuleKey key = ApprovalRuleKeyInternalConverter.ToDomain(approvalRuleKey);

        ApprovalRule rule = await rules.GetRequired(key, cancellationToken);

        return rule;
    }

    public async Task Upsert(ApprovalRule rule, CancellationToken cancellationToken)
    {
        await rules.Upsert(rule, cancellationToken);
    }

    public async Task<ApprovalRule[]> GetAllVersions(EntityTypeKey entityTypeKey, bool isDeletedIncluded, CancellationToken cancellationToken)
    {
        ApprovalRuleKey[] keys = await rules.GetAllVersions(entityTypeKey, isDeletedIncluded, cancellationToken);

        IEnumerable<Task<ApprovalRule>> tasks = keys.Select(k => rules.GetRequired(k, cancellationToken));

        ApprovalRule[] result = await Task.WhenAll(tasks);

        return result;
    }

    public async Task Delete(EntityTypeKey entityTypeKey, Id<User> currentUserId, CancellationToken cancellationToken)
    {
        Audit<ApprovalRule> audit = AuditFactory<ApprovalRule>.CreateNew(currentUserId);

        await rules.Delete(entityTypeKey, audit, cancellationToken);
    }
}
