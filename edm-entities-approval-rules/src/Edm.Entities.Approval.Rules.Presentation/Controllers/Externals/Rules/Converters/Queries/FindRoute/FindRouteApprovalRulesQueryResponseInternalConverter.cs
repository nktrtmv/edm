using Edm.Entities.Approval.Rules.Application.External.Rules.Queries.FindRoute.Contracts;
using Edm.Entities.Approval.Rules.Presentation.Abstractions;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Externals;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Externals.Rules.Converters.Contracts.Routes;
using Edm.Entities.Approval.Rules.Presentation.Converters.Rules.Keys;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Externals.Rules.Converters.Queries.FindRoute;

internal static class FindRouteApprovalRulesQueryResponseInternalConverter
{
    internal static FindRouteApprovalRulesQueryResponse ToDto(FindRouteApprovalRulesQueryResponseInternal response)
    {
        ApprovalRouteDto route = RouteInternalConverter.ToDto(response.Route);

        ApprovalRuleKeyDto approvalRuleKey = ApprovalRuleKeyInternalConverter.ToDto(response.ApprovalRuleKey);

        var result = new FindRouteApprovalRulesQueryResponse
        {
            Route = route,
            ApprovalRuleKey = approvalRuleKey
        };

        return result;
    }
}
