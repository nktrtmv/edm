using Edm.Entities.Approval.Rules.Application.Internal.Groups.Commands.Delete.Contracts;
using Edm.Entities.Approval.Rules.Application.Internal.Services;
using Edm.Entities.Approval.Rules.Domain.Entities.Groups;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules.Services.Updaters;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules.Services.Updaters.Groups.Updaters;
using Edm.Entities.Approval.Rules.Domain.Markers;
using Edm.Entities.Approval.Rules.GenericSubdomain;

using JetBrains.Annotations;

using MediatR;

namespace Edm.Entities.Approval.Rules.Application.Internal.Groups.Commands.Delete;

[UsedImplicitly]
internal sealed class DeleteApprovalGroupsCommandInternalHandler : IRequestHandler<DeleteApprovalGroupsCommandInternal>
{
    public DeleteApprovalGroupsCommandInternalHandler(ApprovalRulesFacade rules)
    {
        Rules = rules;
    }

    private ApprovalRulesFacade Rules { get; }

    public async Task Handle(DeleteApprovalGroupsCommandInternal request, CancellationToken cancellationToken)
    {
        ApprovalRule rule = await Rules.GetRequired(request.ApprovalRuleKey, request.ConcurrencyToken, cancellationToken);

        Id<ApprovalGroup> groupId = IdConverterFrom<ApprovalGroup>.From(request.GroupId);

        Id<User> currentUserId = IdConverterFrom<User>.From(request.CurrentUserId);

        ApprovalRuleUpdater.Update(rule, currentUserId, () => ApprovalGroupsUpdater.RemoveGroup(rule, groupId));

        await Rules.Upsert(rule, cancellationToken);
    }
}
