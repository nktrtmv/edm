using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Rules.Keys;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Groups.Queries.Get.Contracts;

internal static class GetApprovalGroupsQueryBffConverter
{
    internal static GetApprovalGroupsQuery ToDto(GetApprovalGroupsQueryBff query)
    {
        var approvalRuleKey = ApprovalRuleKeyBffConverter.ToDto(query.ApprovalRuleKey);

        var result = new GetApprovalGroupsQuery
        {
            ApprovalRuleKey = approvalRuleKey,
            GroupId = query.GroupId
        };

        return result;
    }
}
