using Edm.Entities.Approval.Rules.Application.Contracts.Rules.Keys;
using Edm.Entities.Approval.Rules.Application.Internal.Groups.Queries.GetAll.Contracts.QueryParams;

using MediatR;

namespace Edm.Entities.Approval.Rules.Application.Internal.Groups.Queries.GetAll.Contracts;

public sealed class GetAllApprovalGroupsQueryInternal : IRequest<GetAllApprovalGroupsQueryResponseInternal>
{
    public GetAllApprovalGroupsQueryInternal(ApprovalRuleKeyInternal approvalRuleKey, GetAllApprovalGroupsQueryParamsInternal? queryParams)
    {
        ApprovalRuleKey = approvalRuleKey;
        QueryParams = queryParams;
    }

    internal ApprovalRuleKeyInternal ApprovalRuleKey { get; }
    internal GetAllApprovalGroupsQueryParamsInternal? QueryParams { get; }
}
