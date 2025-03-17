using Edm.Entities.Approval.Rules.Application.Internal.Graphs.Queries.Get.Contracts;
using Edm.Entities.Approval.Rules.Application.Internal.Services;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules.Services.Updaters.Graphs.Fetchers;
using Edm.Entities.Approval.Rules.GenericSubdomain;

using JetBrains.Annotations;

using MediatR;

namespace Edm.Entities.Approval.Rules.Application.Internal.Graphs.Queries.Get;

[UsedImplicitly]
internal sealed class GetApprovalGraphsQueryInternalHandler(ApprovalRulesFacade rules)
    : IRequestHandler<GetApprovalGraphsQueryInternal, GetApprovalGraphsQueryResponseInternal>
{
    private ApprovalRulesFacade Rules { get; } = rules;

    public async Task<GetApprovalGraphsQueryResponseInternal> Handle(GetApprovalGraphsQueryInternal request, CancellationToken cancellationToken)
    {
        ApprovalRule rule = await Rules.GetRequired(request.ApprovalRuleKey, cancellationToken);

        Id<ApprovalGraph> graphId = IdConverterFrom<ApprovalGraph>.From(request.GraphId);

        ApprovalGraph graph = ApprovalGraphsFetcher.GetRequired(rule, graphId);

        GetApprovalGraphsQueryResponseInternal result =
            GetApprovalGraphsQueryResponseInternalConverter.FromDomain(graph, rule);

        return result;
    }
}
