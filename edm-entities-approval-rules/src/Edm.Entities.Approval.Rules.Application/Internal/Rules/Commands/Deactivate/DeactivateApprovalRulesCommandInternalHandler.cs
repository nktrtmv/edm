using Edm.Entities.Approval.Rules.Application.Internal.Rules.Commands.Deactivate.Contracts;
using Edm.Entities.Approval.Rules.Application.Internal.Services;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules.Services.Updaters;
using Edm.Entities.Approval.Rules.Domain.Markers;
using Edm.Entities.Approval.Rules.GenericSubdomain;

using JetBrains.Annotations;

using MediatR;

namespace Edm.Entities.Approval.Rules.Application.Internal.Rules.Commands.Deactivate;

[UsedImplicitly]
internal sealed class DeactivateApprovalRulesCommandInternalHandler : IRequestHandler<DeactivateApprovalRulesCommandInternal>
{
    public DeactivateApprovalRulesCommandInternalHandler(ApprovalRulesFacade rules)
    {
        Rules = rules;
    }

    private ApprovalRulesFacade Rules { get; }

    public async Task Handle(DeactivateApprovalRulesCommandInternal request, CancellationToken cancellationToken)
    {
        ApprovalRule rule = await Rules.GetRequired(request.Key, request.ConcurrencyToken, cancellationToken);

        Id<User> currentUserId = IdConverterFrom<User>.From(request.CurrentUserId);

        ApprovalRuleUpdater.Deactivate(rule, currentUserId, request.Comment);

        await Rules.Upsert(rule, cancellationToken);
    }
}
