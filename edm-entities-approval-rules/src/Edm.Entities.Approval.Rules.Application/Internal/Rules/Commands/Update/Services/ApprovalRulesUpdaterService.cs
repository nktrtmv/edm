using Edm.Entities.Approval.Rules.Application.Internal.Rules.Commands.Update.Contracts.Rules;
using Edm.Entities.Approval.Rules.Application.Internal.Services;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules.Factories;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules.Services.ActionsExecutors.Actions;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules.Services.ActionsExecutors.Executors;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules.Services.Updaters;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules.ValueObjects.Keys;
using Edm.Entities.Approval.Rules.Domain.Markers;
using Edm.Entities.Approval.Rules.GenericSubdomain;

namespace Edm.Entities.Approval.Rules.Application.Internal.Rules.Commands.Update.Services;

internal sealed class ApprovalRulesUpdaterService(ApprovalRulesFacade rules)
{
    internal async Task<UpdateApprovalRulesCommandResponseFailedDuringUpdateApprovalRuleInternal[]> Update(
        ApprovalRuleKey[] keys,
        ApprovalRulesUpdateAction action,
        bool isDryRun,
        bool isActivationRequired,
        string? comment,
        Id<User> currentUserId,
        CancellationToken cancellationToken)
    {
        var result = new List<UpdateApprovalRulesCommandResponseFailedDuringUpdateApprovalRuleInternal>();

        foreach (ApprovalRuleKey key in keys)
        {
            ApprovalRule[] allVersions = await rules.GetAllVersions(key.EntityTypeKey, false, cancellationToken);

            ApprovalRule rule = CreateNewVersion(allVersions, key, currentUserId);

            string? error = ApprovalRulesUpdateActionExecutor.Execute(rule, action, isDryRun);

            if (error is not null)
            {
                UpdateApprovalRulesCommandResponseFailedDuringUpdateApprovalRuleInternal failedDuringUpdateApprovalRule =
                    UpdateApprovalRulesCommandResponseFailedDuringUpdateApprovalRuleInternalConverter.FromDomain(key, error);

                result.Add(failedDuringUpdateApprovalRule);
            }

            if (isDryRun)
            {
                continue;
            }

            if (isActivationRequired)
            {
                await Activate(allVersions, rule, comment!, currentUserId, cancellationToken);
            }

            await rules.Upsert(rule, cancellationToken);
        }

        return result.ToArray();
    }

    private static ApprovalRule CreateNewVersion(ApprovalRule[] allVersions, ApprovalRuleKey key, Id<User> currentUserId)
    {
        ApprovalRule rule = allVersions.Single(r => r.Version == key.Version);

        int maxVersion = allVersions.Max(r => r.Version);

        ApprovalRule result = ApprovalRuleFactory.CreateNewVersion(rule, key.Version, maxVersion + 1, currentUserId);

        return result;
    }

    private async Task Activate(ApprovalRule[] allVersions, ApprovalRule rule, string comment, Id<User> currentUserId, CancellationToken cancellationToken)
    {
        ApprovalRule? activeVersion = allVersions.SingleOrDefault(v => v.IsActive);

        if (activeVersion is not null)
        {
            ApprovalRuleUpdater.Deactivate(activeVersion, currentUserId, comment);

            await rules.Upsert(activeVersion, cancellationToken);
        }

        ApprovalRuleUpdater.Activate(rule, currentUserId, comment);
    }
}
