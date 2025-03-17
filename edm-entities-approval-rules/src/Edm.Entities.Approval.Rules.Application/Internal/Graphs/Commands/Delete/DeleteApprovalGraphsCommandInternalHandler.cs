using Edm.Entities.Approval.Rules.Application.Internal.Graphs.Commands.Delete.Contracts;
using Edm.Entities.Approval.Rules.Application.Internal.Services;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules.Services.Updaters;
using Edm.Entities.Approval.Rules.Domain.Markers;
using Edm.Entities.Approval.Rules.GenericSubdomain;

using JetBrains.Annotations;

using MediatR;

namespace Edm.Entities.Approval.Rules.Application.Internal.Graphs.Commands.Delete;

[UsedImplicitly]
internal sealed class DeleteApprovalGraphsCommandInternalHandler : IRequestHandler<DeleteApprovalGraphsCommandInternal>
{
    public DeleteApprovalGraphsCommandInternalHandler(ApprovalRulesFacade rules)
    {
        Rules = rules;
    }

    private ApprovalRulesFacade Rules { get; }

    public async Task Handle(DeleteApprovalGraphsCommandInternal request, CancellationToken cancellationToken)
    {
        ApprovalRule rule = await Rules.GetRequired(request.ApprovalRuleKey, request.ConcurrencyToken, cancellationToken);

        Id<ApprovalGraph> graphId = IdConverterFrom<ApprovalGraph>.From(request.GraphId);

        Id<User> currentUserId = IdConverterFrom<User>.From(request.CurrentUserId);

        ApprovalRuleUpdater.Update(rule, currentUserId, () => rule.RemoveGraphById(graphId));

        await Rules.Upsert(rule, cancellationToken);
    }
}
