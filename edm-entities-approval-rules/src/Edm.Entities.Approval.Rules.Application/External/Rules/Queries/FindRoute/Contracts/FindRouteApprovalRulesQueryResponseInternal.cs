using Edm.Entities.Approval.Rules.Application.Contracts.Rules.Keys;
using Edm.Entities.Approval.Rules.Application.External.Rules.Queries.FindRoute.Contracts.Routes;

namespace Edm.Entities.Approval.Rules.Application.External.Rules.Queries.FindRoute.Contracts;

public sealed class FindRouteApprovalRulesQueryResponseInternal
{
    internal FindRouteApprovalRulesQueryResponseInternal(RouteInternal route, ApprovalRuleKeyInternal approvalRuleKey)
    {
        Route = route;
        ApprovalRuleKey = approvalRuleKey;
    }

    public RouteInternal Route { get; }
    public ApprovalRuleKeyInternal ApprovalRuleKey { get; }
}
