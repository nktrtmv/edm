using Edm.Entities.Approval.Rules.Application.Contracts.Rules.Keys;
using Edm.Entities.Approval.Rules.Application.External.Rules.Queries.FindRoute.Contracts.Routes;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Routes;

namespace Edm.Entities.Approval.Rules.Application.External.Rules.Queries.FindRoute.Contracts;

internal static class FindRouteQueryResponseInternalConverter
{
    internal static FindRouteApprovalRulesQueryResponseInternal FromDomain(Route route, ApprovalRule rule)
    {
        RouteInternal routeInternal = RouteInternalConverter.FromDomain(route);

        ApprovalRuleKeyInternal approvalRuleKey = ApprovalRuleKeyInternalConverter.FromDomain(rule);

        var result = new FindRouteApprovalRulesQueryResponseInternal(routeInternal, approvalRuleKey);

        return result;
    }
}
