using Edm.Entities.Approval.Rules.Application.Internal.Groups.Commands.Create.Contracts;
using Edm.Entities.Approval.Rules.Application.Internal.Groups.Commands.Create.Contracts.Kinds;
using Edm.Entities.Approval.Rules.Application.Internal.Services;
using Edm.Entities.Approval.Rules.Domain.Entities.Groups;
using Edm.Entities.Approval.Rules.Domain.Entities.Groups.Factories;
using Edm.Entities.Approval.Rules.Domain.Entities.Groups.Factories.Kinds;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules.Services.Updaters;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules.Services.Updaters.Groups.Updaters;
using Edm.Entities.Approval.Rules.Domain.Markers;
using Edm.Entities.Approval.Rules.GenericSubdomain;

using JetBrains.Annotations;

using MediatR;

namespace Edm.Entities.Approval.Rules.Application.Internal.Groups.Commands.Create;

[UsedImplicitly]
internal sealed class CreateApprovalGroupsCommandInternalHandler : IRequestHandler<CreateApprovalGroupsCommandInternal, CreateApprovalGroupsCommandResponseInternal>
{
    public CreateApprovalGroupsCommandInternalHandler(ApprovalRulesFacade rules)
    {
        Rules = rules;
    }

    private ApprovalRulesFacade Rules { get; }

    public async Task<CreateApprovalGroupsCommandResponseInternal> Handle(CreateApprovalGroupsCommandInternal request, CancellationToken cancellationToken)
    {
        ApprovalRule rule = await Rules.GetRequired(request.ApprovalRuleKey, cancellationToken);

        ApprovalGroupKind kind = ApprovalGroupKindInternalConverter.ToDomain(request.Kind);

        ApprovalGroup group = ApprovalGroupFactory.CreateNew(kind, request.DisplayName);

        Id<User> currentUserId = IdConverterFrom<User>.From(request.CurrentUserId);

        ApprovalRuleUpdater.Update(rule, currentUserId, () => ApprovalGroupsUpdater.AddGroup(rule, group));

        await Rules.Upsert(rule, cancellationToken);

        CreateApprovalGroupsCommandResponseInternal result =
            CreateApprovalGroupsCommandResponseInternalConverter.FromDomain(group);

        return result;
    }
}
