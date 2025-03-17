using Edm.Entities.Approval.Rules.Application.Contracts.Rules.Keys;
using Edm.Entities.Approval.Rules.Application.Internal.Rules.Commands.CreateNewVersion.Contracts;
using Edm.Entities.Approval.Rules.Application.Internal.Services;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules.Factories;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules.ValueObjects.Keys;
using Edm.Entities.Approval.Rules.Domain.Markers;
using Edm.Entities.Approval.Rules.GenericSubdomain;

using JetBrains.Annotations;

using MediatR;

namespace Edm.Entities.Approval.Rules.Application.Internal.Rules.Commands.CreateNewVersion;

[UsedImplicitly]
internal sealed class CreateNewVersionApprovalRulesCommandInternalHandler(ApprovalRulesFacade rulesFacade)
    : IRequestHandler<CreateNewVersionApprovalRulesCommandInternal, CreateNewVersionApprovalRulesCommandResponseInternal>
{
    public async Task<CreateNewVersionApprovalRulesCommandResponseInternal> Handle(
        CreateNewVersionApprovalRulesCommandInternal request,
        CancellationToken cancellationToken)
    {
        ApprovalRuleKey originalApprovalRuleKey = ApprovalRuleKeyInternalConverter.ToDomain(request.OriginalApprovalRuleKey);

        ApprovalRule[] rules = await rulesFacade.GetAllVersions(originalApprovalRuleKey.EntityTypeKey, false, cancellationToken);

        ApprovalRule originalApprovalRule = rules.Single(r => r.Version == originalApprovalRuleKey.Version);

        int newVersion = rules.Max(r => r.Version) + 1;

        Id<User> currentUserId = IdConverterFrom<User>.From(request.CurrentUserId);

        ApprovalRule newRule = ApprovalRuleFactory.CreateNewVersion(originalApprovalRule, originalApprovalRuleKey.Version, newVersion, currentUserId);

        await rulesFacade.Upsert(newRule, cancellationToken);

        ApprovalRuleKeyInternal newApprovalRuleKey = ApprovalRuleKeyInternalConverter.FromDomain(newRule);

        var result = new CreateNewVersionApprovalRulesCommandResponseInternal(newApprovalRuleKey);

        return result;
    }
}
