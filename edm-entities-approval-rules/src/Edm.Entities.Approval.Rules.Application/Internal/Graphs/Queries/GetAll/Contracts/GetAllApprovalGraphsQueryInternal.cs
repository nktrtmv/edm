using Edm.Entities.Approval.Rules.Application.Contracts.Rules.Keys;

using MediatR;

namespace Edm.Entities.Approval.Rules.Application.Internal.Graphs.Queries.GetAll.Contracts;

public sealed class GetAllApprovalGraphsQueryInternal : IRequest<GetAllApprovalGraphsQueryResponseInternal>
{
    public GetAllApprovalGraphsQueryInternal(ApprovalRuleKeyInternal approvalRuleKey)
    {
        ApprovalRuleKey = approvalRuleKey;
    }

    internal ApprovalRuleKeyInternal ApprovalRuleKey { get; }
}
