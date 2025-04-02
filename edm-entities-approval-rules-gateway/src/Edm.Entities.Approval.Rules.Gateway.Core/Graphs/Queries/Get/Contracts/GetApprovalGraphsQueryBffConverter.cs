using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Rules.Keys;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Queries.Get.Contracts;

internal static class GetApprovalGraphsQueryBffConverter
{
    internal static GetApprovalGraphsQuery ToDto(GetApprovalGraphsQueryBff query)
    {
        var approvalRuleKey = ApprovalRuleKeyBffConverter.ToDto(query.ApprovalRuleKey);

        var result = new GetApprovalGraphsQuery
        {
            ApprovalRuleKey = approvalRuleKey,
            GraphId = query.GraphId
        };

        return result;
    }
}
