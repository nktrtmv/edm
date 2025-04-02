using Edm.Entities.Approval.Rules.Application.Internal.Graphs.Commands.Update.Contracts;
using Edm.Entities.Approval.Rules.Application.Internal.Graphs.Contracts.Graphs;
using Edm.Entities.Approval.Rules.Application.Internal.Services;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules.Services.Updaters;
using Edm.Entities.Approval.Rules.Domain.Markers;
using Edm.Entities.Approval.Rules.GenericSubdomain;

using JetBrains.Annotations;

using MediatR;

namespace Edm.Entities.Approval.Rules.Application.Internal.Graphs.Commands.Update;

[UsedImplicitly]
internal sealed class UpdateApprovalGraphsCommandInternalHandler(ApprovalRulesFacade rules) : IRequestHandler<UpdateApprovalGraphsCommandInternal>
{
    public async Task Handle(UpdateApprovalGraphsCommandInternal request, CancellationToken cancellationToken)
    {
        ApprovalRule rule = await rules.GetRequired(request.ApprovalRuleKey, request.ConcurrencyToken, cancellationToken);

        ApprovalGraph graph = ApprovalGraphInternalConverter.ToDomain(request.Graph);

        Id<User> currentUserId = IdConverterFrom<User>.From(request.CurrentUserId);

        ApprovalRuleUpdater.Update(rule, currentUserId, () => rule.AddOrUpdateGraph(graph));

        await rules.Upsert(rule, cancellationToken);
    }
}
