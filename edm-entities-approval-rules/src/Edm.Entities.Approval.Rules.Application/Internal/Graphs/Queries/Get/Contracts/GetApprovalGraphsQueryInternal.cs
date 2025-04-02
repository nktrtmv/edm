using Edm.Entities.Approval.Rules.Application.Contracts.Rules.Keys;
using Edm.Entities.Approval.Rules.Application.Internal.Graphs.Contracts.Graphs;
using Edm.Entities.Approval.Rules.GenericSubdomain;

using MediatR;

namespace Edm.Entities.Approval.Rules.Application.Internal.Graphs.Queries.Get.Contracts;

public sealed class GetApprovalGraphsQueryInternal : IRequest<GetApprovalGraphsQueryResponseInternal>
{
    public GetApprovalGraphsQueryInternal(ApprovalRuleKeyInternal approvalRuleKey, Id<ApprovalGraphInternal> graphId)
    {
        ApprovalRuleKey = approvalRuleKey;
        GraphId = graphId;
    }

    internal ApprovalRuleKeyInternal ApprovalRuleKey { get; }
    internal Id<ApprovalGraphInternal> GraphId { get; }
}
