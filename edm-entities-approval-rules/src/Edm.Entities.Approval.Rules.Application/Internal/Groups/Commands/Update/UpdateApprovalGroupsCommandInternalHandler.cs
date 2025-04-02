using Edm.Entities.Approval.Rules.Application.Internal.Groups.Commands.Update.Contracts;
using Edm.Entities.Approval.Rules.Application.Internal.Groups.Contracts.Groups;
using Edm.Entities.Approval.Rules.Application.Internal.Services;
using Edm.Entities.Approval.Rules.Domain.Entities.Groups;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules.Services.Updaters;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules.Services.Updaters.Groups.Updaters;
using Edm.Entities.Approval.Rules.Domain.Markers;
using Edm.Entities.Approval.Rules.GenericSubdomain;

using JetBrains.Annotations;

using MediatR;

namespace Edm.Entities.Approval.Rules.Application.Internal.Groups.Commands.Update;

[UsedImplicitly]
internal sealed class UpdateApprovalGroupsCommandInternalHandler(ApprovalRulesFacade rules) : IRequestHandler<UpdateApprovalGroupsCommandInternal>
{
    private ApprovalRulesFacade Rules { get; } = rules;

    public async Task Handle(UpdateApprovalGroupsCommandInternal request, CancellationToken cancellationToken)
    {
        ApprovalRule rule = await Rules.GetRequired(request.ApprovalRuleKey, request.ConcurrencyToken, cancellationToken);

        ApprovalGroup group = ApprovalGroupInternalConverter.ToDomain(request.Group);

        Id<User> currentUserId = IdConverterFrom<User>.From(request.CurrentUserId);

        ApprovalRuleUpdater.Update(rule, currentUserId, () => ApprovalGroupsUpdater.UpdateGroup(rule, group));

        await Rules.Upsert(rule, cancellationToken);
    }
}
