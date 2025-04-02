using Edm.Entities.Approval.Rules.Application.Internal.Graphs.Commands.Create.Contracts;
using Edm.Entities.Approval.Rules.Application.Internal.Services;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.Factories;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules.Services.Updaters;
using Edm.Entities.Approval.Rules.Domain.Markers;
using Edm.Entities.Approval.Rules.GenericSubdomain;

using JetBrains.Annotations;

using MediatR;

namespace Edm.Entities.Approval.Rules.Application.Internal.Graphs.Commands.Create;

[UsedImplicitly]
internal sealed class CreateApprovalGraphsCommandInternalHandler
    : IRequestHandler<CreateApprovalGraphsCommandInternal, CreateApprovalGraphsCommandResponseInternal>
{
    public CreateApprovalGraphsCommandInternalHandler(ApprovalRulesFacade rules)
    {
        Rules = rules;
    }

    private ApprovalRulesFacade Rules { get; }

    public async Task<CreateApprovalGraphsCommandResponseInternal> Handle(CreateApprovalGraphsCommandInternal request, CancellationToken cancellationToken)
    {
        ApprovalRule rule = await Rules.GetRequired(request.ApprovalRuleKey, cancellationToken);

        ApprovalGraph graph = ApprovalGraphFactory.CreateNew(request.DisplayName);

        Id<User> currentUserId = IdConverterFrom<User>.From(request.CurrentUserId);

        ApprovalRuleUpdater.Update(rule, currentUserId, () => rule.AddOrUpdateGraph(graph));

        await Rules.Upsert(rule, cancellationToken);

        CreateApprovalGraphsCommandResponseInternal result =
            CreateApprovalGraphsCommandResponseInternalConverter.FromDomain(graph);

        return result;
    }
}
